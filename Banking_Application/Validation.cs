using System;

namespace Banking_Application
{
    class Validation
    {
        //Validations of attributes
        public static void yearOfBirth(DateTime dob)
        {
            if (DateTime.Now.Year - dob.Year < 16)
            {
                throw new Exception(ErrorMessage.InvalidDOB);
            }
        }

        public static void contactNumber(string contact)
        {
            bool valid = true;

            if (contact.Length < 0 && contact.Length != 10)
            {
                valid = false;
            }
            else
            {
                for (int i = 0; i < contact.Length; i++)
                {
                    if (!Char.IsDigit(contact[i]))
                    {
                        valid = false;
                        break;
                    }
                }
            }

            if (!valid)
                throw new Exception(ErrorMessage.InvalidContact);
        }
        
        public static void ForFirstName(string firstName)
        {
            if (firstName.Length == 0)
                throw new Exception(ErrorMessage.InvalidFirstName);
        }

        public static void ForLastName(string lastName)
        {
            if (lastName.Length == 0)
                throw new Exception(ErrorMessage.InvalidLastName);
        }

        public static void ForAddress(string address)
        {
            if (address.Length == 0)
                throw new Exception(ErrorMessage.InvalidAddress);
        }

        public static void ForContact(string contact)
        {
            bool valid = true;
            if (contact.Length > 0 && contact.Length != 10)
                valid = false;
            else
            {
                for (int i = 0; i < contact.Length; i++)
                    if (!Char.IsDigit(contact[i]))
                    {
                        valid = false;
                        break;
                    }
            }
            if (!valid)
                throw new Exception(ErrorMessage.InvalidContact);
        }
        
        //Validations of attributes
        public static void OpenedDate(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) < 0)
            {
                throw new Exception(ErrorMessage.InvalidOpenedDate);
            }
        }
        //Validations related to Accounts

        public static void CalculateInterest(Account account)
        {
            if (!account.Active)
            {
                throw new Exception(ErrorMessage.InactiveAccount);
            }
        }
        
        public static void ClosedDate(Account account)
        {
            if (account.Active)
            {
                throw new Exception(ErrorMessage.ActiveAccount);
            }
        }

        public static void Balance(double balance)
        {
            if (balance < 0)
            {
                throw new Exception(ErrorMessage.AccountBalance);
            }
        }

        public static void ForTransferring(Account sourceAccount, Account destinationAccount, double amount)
        {
            if (!sourceAccount.Active || !destinationAccount.Active)
                throw new Exception(ErrorMessage.InactiveAccount);
            if (amount<=0)
                throw new Exception(ErrorMessage.InvalidAmount);
            if(amount > sourceAccount.Balance)
                throw new Exception(ErrorMessage.ExceededAmount);
        }

        public static void ForDeposit(Account account, double amount)
        {
            if (!account.Active)
            {
                throw new Exception(ErrorMessage.InactiveAccount);
            }

            if (amount < 0)
            {
                throw new Exception(ErrorMessage.InvalidAmount);
            }
        }

        public static void ForWithdraw(Account account, double amount)
        {
            if (!account.Active)
            {
                throw new Exception(ErrorMessage.InactiveAccount);
            }

            if (amount <= 0)
            {
                throw new Exception(ErrorMessage.InvalidAmount);
            }

            if (amount < account.Balance)
            {
                throw new Exception(ErrorMessage.ExceededAmount);
            }
        }

        public static void MonthlyDeposit(TypeTwoAccount account, double amount)
        {
            if (!account.Active)
            {
                throw new Exception(ErrorMessage.InactiveAccount);
            }
            if (amount <= 0 )
            {
                throw new Exception(ErrorMessage.InvalidAmount);
            }
        }
        
        public static void ForCreatingCustomer(string firstName, string lastName, string address, DateTime dob, string contact, string email)
        {
            try
            {
                ForFirstName(firstName);
                ForLastName(lastName);
                ForAddress(address);
                yearOfBirth(dob);
                ForContact(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}