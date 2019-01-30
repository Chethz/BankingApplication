using System;
using System.Collections.Generic;
using System.IO;

namespace Banking_Application
{
    abstract class Account
    {
        //_Count hold the current number of accounts in the system
        private static ulong _Count = 0;

        //Attributes
        private static ulong _ID;
        public ulong ID
        {
            get { return _ID; }
        }

        protected Customer _Owner;
        public string Owner
        {
            get { return _Owner.ToString(); }
        }

        protected DateTime _OpenDate;
        public DateTime OpenDate
        {
            get { return OpenDate; }
        }

        protected DateTime _ClosedDate;
        public DateTime ClosedDate
        {
            get
            {
                try
                {
                    Validation.ClosedDate(this);
                    return _ClosedDate;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected bool _Active;
        public bool Active
        {
            get { return _Active; }
        }

        protected double _Balance = 0;
        public double Balance
        {
            get { return _Balance; }
            set
            {
                try
                {
                    Validation.Balance((double)value);
                    _Balance = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
        //Constructor
        protected Account(ulong accountID, Customer owner, DateTime openedDate, double initBalance = 0)
        {
            _ID = accountID;
            _Count = Math.Max(_Count, _ID);
            _Owner = owner;
            _Owner.AddAccount(this);
            _OpenDate = openedDate;
            _Balance = initBalance;
            _Active = true;
        }


        protected Account(Customer owner, DateTime openDate, double initBalance = 0) : this(_Count + 1, owner, openDate,
            initBalance)
        {
        }

        protected Account(Customer owner, double initBalance = 0) : this(owner, DateTime.Now, initBalance)
        {
        }

        public void Close()
        {
            _Active = false;
            _ClosedDate = DateTime.Now;
        }

        public override string ToString()
        {
            if (_Active)
            {
                return string.Format("ID:{0,-5} Open Date: {1,-12} Balance: {2,-10:0,0.0} Owner: {3,-7} {4,-10}", _ID,
                    _OpenDate.ToShortDateString(), _Balance, _Owner.FirstName, _Owner.LastName,
                    _ClosedDate.ToShortDateString());
            }
            else
            {
                return string.Format(
                    "ID: {0,-5} Opened Date: {1,-12} Balance: {2,-10:0,0.0} Owner: {3,-7} {4,-10} - Closed on {5}", _ID,
                    _OpenDate.ToShortDateString(), _Balance, _Owner.FirstName, _Owner.LastName,
                    _ClosedDate.ToShortDateString());
            }
        }

        public void ToStream(StreamWriter sw)
        {
            if (this.GetType()==typeof(TypeOneAccount))
            {
                sw.WriteLine(1);
            }
            else
            {
                sw.WriteLine(2);
            }
            sw.WriteLine(_ID);
            sw.WriteLine(_Owner.ID);
            sw.WriteLine(_OpenDate.ToShortDateString());
            if (_Active)
            {
                sw.WriteLine();
            }
            else
            {
                sw.WriteLine(_ClosedDate.ToShortDateString());
            }
            sw.WriteLine(_Balance);
        }
        
        //Abstract methods
        public abstract double CalculateInterest();
        
        //Virtual methods
        public virtual void Transfer(Account toAccount, double amount)
        {
            try
            {
                ValidationForTransferring(toAccount, amount);
                Balance -= amount;
                toAccount.Balance += amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void UpdateBalance()
        {
            double interest = CalculateInterest();
            _Balance += interest;
        }
        
        //Validation methods
        protected virtual void ValidationForTransferring(Account destinationAccount, double amount)
        {
            Validation.ForTransferring(this, destinationAccount, amount);
        }
        
        //Factory methods
        
        public static Account CreateAccount(int accountType, Customer owner, DateTime openedDate, double initBalance = 0)
        {
            try
            {
                Validation.OpenedDate(openedDate);
                if (accountType == 1)
                    return TypeOneAccount.CreateTypeOneAccount(owner, openedDate, initBalance);
                else if (accountType == 2)
                    return TypeTwoAccount.CreateTypeTwoAccount(owner, openedDate, initBalance);
                else
                    throw new Exception(ErrorMessage.InvalidAccountType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static Account CreateAccount(int accountType, ulong accountID, Customer owner, DateTime openedDate, double initBalance = 0)
        {
            try
            {
                Validation.OpenedDate(openedDate);
                if (accountType == 1)
                    return TypeOneAccount.CreateTypeOneAccount(accountID, owner, openedDate, initBalance);
                else if (accountType == 2)
                    return TypeTwoAccount.CreateTypeTwoAccount(accountID, owner, openedDate, initBalance);
                else
                    throw new Exception(ErrorMessage.InvalidAccountType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Account CreateAccount(int accountType, List<Customer> customers, ulong ownerID, double initBalance = 0)
        {
            return CreateAccount(accountType, customers, ownerID, DateTime.Now, initBalance);
        }
        
        public static Account CreateAccount(int accountType, List<Customer> customers, ulong ownerID,
            DateTime openedDate, double initialBalance = 0)
        {
            Customer owner = Utility.SearchCustomer(customers, ownerID);
            if (owner == null)
            {
                throw new Exception(ErrorMessage.NoMatchingCustomer);
            }
            return CreateAccount(accountType, owner, openedDate, initialBalance);
        }
        
        private static Account CreateAccount(int accountType, ulong accountID, List<Customer> customers, ulong ownerID, DateTime openedDate, double initBalance = 0)
        {
            Customer owner = Utility.SearchCustomer(customers, ownerID);
            if (owner == null)
            {
                throw new Exception(ErrorMessage.NoMatchingCustomer);
            }
            return CreateAccount(accountType, accountID, owner, openedDate, initBalance);
        }
        
        //create account from stream reader
        public static Account CreateAccount(StreamReader sReader, List<Customer> customers)
        {
            try
            {
                int accountType = Convert.ToInt32(sReader.ReadLine());
                ulong accountID = Convert.ToUInt32(sReader.ReadLine());
                ulong ownerID = Convert.ToUInt32(sReader.ReadLine());
                DateTime openedDate = Convert.ToDateTime(sReader.ReadLine());
                string closeDdateString = sReader.ReadLine();
                DateTime closedDate = DateTime.Now;
                if (closeDdateString.Length != 0)
                {
                    closedDate = Convert.ToDateTime(closeDdateString);
                }
                double balance = Convert.ToDouble(sReader.ReadLine());
                Account account = CreateAccount(accountType, accountID, customers, ownerID, openedDate, balance);
                if (closeDdateString.Length != 0)
                {
                    account._Active = false;
                    account._ClosedDate = closedDate;
                }
                return account;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}