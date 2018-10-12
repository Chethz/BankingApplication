using System;

namespace Banking_Application
{
    public class Account
    {
        //Count hold the current nmber of accounts in the system
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
                return string.Format("ID:{0,-5} Open Date: {1,-12} Balance: {2,-10:0,0.0} Owner: {3,-7} {4,-10}", _ID,
                    _OpenDate.ToShortDateString(), _Balance, _Owner.FirstName, _Owner.LastName,
                    _ClosedDate.ToShortDateString());
            else
                return string.Format("ID: {0,-5} Opened Date: {1,-12} Balance: {2,-10:0,0.0} Owner: {3,-7} {4,-10} - Closed on {5}", _ID, _OpenDate.ToShortDateString(), _Balance, _Owner.FirstName, _Owner.LastName, _ClosedDate.ToShortDateString());
        }
    }
}