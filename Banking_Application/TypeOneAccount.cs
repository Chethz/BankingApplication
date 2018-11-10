using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Banking_Application
{
    class TypeOneAccount : Account
    {
        //Attributes
        private static double _InterestRate = 2.0;
        public static double InterestRate
        {
            get { return InterestRate; }
        }
        
        //methods
        //Constructores
        protected TypeOneAccount(ulong accountID, Customer owner, DateTime openedDate, double initBalance = 0) : base(accountID, owner, openedDate, initBalance)
        {
        }

        protected TypeOneAccount(Customer owner, DateTime openedDate, double initBalance = 0) : base(owner, openedDate, initBalance)
        {
        }

        protected TypeOneAccount(Customer owner, double initBalance = 0) : base(owner, initBalance)
        {
        }

        public void Deposit(double amount)
        {
            try
            {
                Validation.ForDeposit(this, amount);
                Balance -= amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Withdraw(double amount)
        {
            try
            {
                Validation.ForWithdraw(this, amount);
                Balance -= amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double CalculateInterest()
        {
            try
            {
                Validation.CalculateInterest(this);

                DateTime refDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                TimeSpan span;

                if (DateTime.Compare(OpenDate, refDate) < 0)
                {
                    span = DateTime.Now.Subtract(refDate);
                }
                else
                {
                    span = DateTime.Now.Subtract(OpenDate);
                }

                return _InterestRate / 365 / 100 * span.Days * Balance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Factory methods
        //Create using constructors
        public static TypeOneAccount CreateTypeOneAccount(Customer owner, DateTime openedDate, double initialBalance = 0)
        {
            return new TypeOneAccount(owner, openedDate, initialBalance);
        }

        public static TypeOneAccount CreateTypeOneAccount(Customer owner, double openedDate)
        {
            return new TypeOneAccount(owner, openedDate);
        }
        
        //create Account from text file 
        public static TypeOneAccount CreateTypeOneAccount(ulong accountID, Customer owner,DateTime openedDate,  double initialBalance = 0)
        {
            return new TypeOneAccount(accountID, owner, openedDate, initialBalance);
        }

        public static TypeOneAccount CreateTypeOneAccount(ulong accountID, Customer owner, double initialBalance)
        {
            return new TypeOneAccount(accountID, owner, DateTime.Now, initialBalance);
        }
        
        public static TypeOneAccount CreateTypeOneAccount(List<Customer> customers, ulong ownerID, DateTime openedDate, double initBalance = 0)
        { 
            return (TypeOneAccount) Account.CreateAccount(1, customers, ownerID, openedDate, initBalance);
        }

        public static TypeOneAccount CreateTypeOneAccount(List<Customer> customers, ulong ownerID, double initBalance = 0)
        {
            return CreateTypeOneAccount(customers, ownerID, DateTime.Now, initBalance);
        }

    }
}