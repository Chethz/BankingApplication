using System;

namespace Banking_Application
{
    public class Validation
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
        
        //Validations of attributes
        
        //Validations related to Accounts

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
    }
}