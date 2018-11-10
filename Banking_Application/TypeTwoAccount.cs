using System;
using System.Collections.Generic;

namespace Banking_Application
{
    class TypeTwoAccount : Account
    {
        //Attributes
        private static double _AnualInterestRate = 3.0;
        public static double AnualInterestRate
        {
            get { return _AnualInterestRate; }
        }

        private static double _DepositInterestRate = 4.0;
        public static double DepositInterestRate
        {
            get { return _DepositInterestRate; }
        }

        private double _MonthlyDeposit = 0;
        public double MonthlyDeposit
        {
            get { return _MonthlyDeposit; }
            set
            {
                try
                {
                    Validation.MonthlyDeposit(this,value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
        //Methods
        //Constructor 1
        public TypeTwoAccount(ulong accountID, Customer owner, DateTime openedDate, double initialBalance = 0) : base(
            accountID, owner, openedDate, initialBalance)
        {
        }

        //Constructor 2
        public TypeTwoAccount(Customer owner, DateTime openedDate, double initialBalance = 0) : base(owner, openedDate,
            initialBalance)
        {
        }
        
        //Constructor 3
        public TypeTwoAccount(Customer owner, double initBalance = 0) : base(owner, initBalance)
        {
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

                return _AnualInterestRate / 365 / 100 * span.Days * Balance +
                       _DepositInterestRate / 365 / 100 * span.Days * _MonthlyDeposit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void ValidationForTransferring(Account destinationAccount, double amount)
        {
            base.ValidationForTransferring(destinationAccount, amount);
            if (destinationAccount.Owner != this.Owner)
            {
                throw new Exception(ErrorMessage.InvalidCustomer);
            }

            if (destinationAccount.GetType() != typeof(TypeOneAccount))
            {
                throw new Exception(ErrorMessage.InvalidTransferredAccount);
            }
        }

        public override void UpdateBalance()
        {
            base.UpdateBalance();
            _MonthlyDeposit = 0;
        }
        
       //Create accounts using constructor
        public static TypeTwoAccount CreateTypeTwoAccount(Customer owner, DateTime openedDate,
            double initialBalance = 0)
        {
            return new TypeTwoAccount(owner, openedDate, initialBalance);
        }

        public static TypeTwoAccount CreateTypeTwoAccount(Customer owner, double initialBalance = 0)
        {
            return new TypeTwoAccount(owner, DateTime.Now, initialBalance);
        }
        
        //Create account from file
        public static TypeTwoAccount CreateTypeTwoAccount(ulong accountID, Customer owner, DateTime openedDate,
            double initialBalance = 0)
        {
            return new TypeTwoAccount(accountID, owner, openedDate, initialBalance);
        }

        public static TypeTwoAccount CreateTypeTwoAccount(ulong accountID, Customer owner, double initialBalance = 0)
        {
            return new TypeTwoAccount(accountID, owner, DateTime.Now, initialBalance);
        }

        public static TypeTwoAccount CreateTypeTwoAccount(List<Customer> customer, ulong ownerID, DateTime openedDate,
            double initialBalance = 0)
        {
            return (TypeTwoAccount) Account.CreateAccount(2, customer, ownerID, openedDate, initialBalance);
        }
        
        public static TypeTwoAccount CreateType2Account(List<Customer> customers, ulong ownerID, double initBalance = 0)
        {
            return CreateTypeTwoAccount(customers, ownerID, DateTime.Now, initBalance);
        }
    }
}