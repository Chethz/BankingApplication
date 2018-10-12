namespace Banking_Application
{
    public class ErrorMessage
    {
        private static string _InvalidDOB = "Customer must be atleast 16 years of old";
        public static string InvalidDOB
        {
            get { return _InvalidDOB; }
        }

        private static string _InvalidContact = "Invalid Contact must be 10 digits";
        public static string InvalidContact
        {
            get { return _InvalidContact; }
        }

        private static string _ActiveAccount = "This account is still active!";
        public static string ActiveAccount
        {
            get { return _ActiveAccount; }
        }

        private static string _AccountBalance = "Balance must be grater than 0!";
        public static string AccountBalance
        {
            get { return _AccountBalance; }
        }
    }
}