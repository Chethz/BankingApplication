using System;
using System.Collections.Generic;

namespace Banking_Application
{
    class Utility
    {
        public static Customer SearchCustomer(List<Customer> customers, ulong ID)
        {
            foreach (Customer customer in customers)
            {
                if (customer.ID == ID)
                {
                    return customer;
                }
            }
            return null;
        }
        public static Account SearchAccount(List<Account> accounts, ulong ID)
        {
            foreach (Account account in accounts)
            {
                if (account.ID == ID)
                {
                    return account;
                }
            }
            return null;
        }

        public static bool DoesExist(List<Customer> customers, string firstName, string lastName)
        {
            foreach (Customer customer in customers)
            {
                if (customer.FirstName.ToLower() == firstName.ToLower() &&
                    customer.LastName.ToLower() == lastName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Customer> SearchCustomers(List<Customer> customers, string firstName, string lastName, string address, DateTime dob, string contact, string email)
        {
            List<Customer> results = new List<Customer>();
            foreach (Customer customer in customers)
            {
                if (customer.FirstName == firstName || customer.LastName == lastName || customer.Address == address ||
                    customer.DOB == dob || customer.Contact == contact || customer.Email == email)
                {
                    results.Add(customer);
                }
            }
            return results;
        }
    }
}