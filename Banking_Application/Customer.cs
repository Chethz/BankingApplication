using System;
using System.Collections.Generic;

namespace Banking_Application
{
    public class Customer
    {
        //Holding unique number for the account
        private static ulong _Count = 0;

        // Customer class Attributes
        private ulong _ID;
        public ulong ID
        {
            get { return _ID; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set
            {
                try
                {
                    Validation.yearOfBirth(value);
                    _DOB = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private string _Contact;
        public string Contact
        {
            get { return _Contact; }
            set
            {
                try
                {
                    Validation.contactNumber(value);
                    _Contact = value;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        private List<Account> _Accounts;
        
        //Customer class Methods 
        //Constructor
        private Customer(ulong customerID, string firstName, string lastName, string address, DateTime dob, string contact = "", string email = "")
        {
            _ID = customerID;
            _Count = Math.Max(_Count, _ID);
            _FirstName = firstName;
            _LastName = lastName;
            _Address = address;
            _DOB = dob;
            _Contact = contact;
            _Email = email;
            _Accounts = new List<Account>();
        }
        
        //Constructor two
        private Customer(string firstName, string lastName, string address, DateTime dob, string contact = "",
            string email = "") : this(_Count + 1, firstName, lastName, address, dob, contact, email)
        {
        }
        
        //Copy constructor
        private Customer(Customer c) : this(c.FirstName, c.LastName, c.Address, c.DOB, c.Contact, c._Email)
        {
            _Accounts = new List<Account>(c._Accounts);
        }

        public void AddAccount(Account account)
        {
            _Accounts.Add(account);
        }

        public double SumBalance()
        {
            double sumBalance = 0;

            foreach (var accounts in _Accounts)
            {
                sumBalance += accounts.Balance;
            }
            return sumBalance;
        }
    }
}