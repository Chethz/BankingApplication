using System;

namespace Banking_Application
{
    class View
    {
        BankingSystem _BankingSystem;

        public View(BankingSystem bankingSystem)
        {
            this._BankingSystem = bankingSystem;
        }

        public void MainMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\n--------------Main Menu-------------------");
                Console.WriteLine("Enter 1 if you want to create a new customer");
                Console.WriteLine("Enter 2 if you want to search a customer");
                Console.WriteLine("Enter 3 if you want to open an account");
                Console.WriteLine("Enter 4 if you want to search an account");
                Console.WriteLine("Enter 5 if you want to transfer money");
                Console.WriteLine("Enter 6 if you want to deposit");
                Console.WriteLine("Enter 7 if you want to withdraw");
                Console.WriteLine("Enter 8 if you want to set monthly deposit");
                Console.WriteLine("Enter any other keys if you want to exit");
                Console.Write("Your option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        SearchCustomer();
                        break;
                    case "3":
                        OpenAccount();
                        break;
                    case "4":
                        SearchAccount();
                        break;
                    case "5":
                        Transfer();
                        break;
                    case "6":
                        Deposit();
                        break;
                    case "7":
                        Withdraw();
                        break;
                    case "8":
                        MonthlyDeposit();
                        break;
                    default:
                        Console.WriteLine("Thank you for using our system. Bye!");
                        end = true;
                        break;
                }
            }
            try
            {
                _BankingSystem.End();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateCustomer()
        {

        }

        private void SearchCustomer()
        {

        }

        private void OpenAccount()
        {

        }

        private void SearchAccount()
        {

        }

        private void Transfer()
        {

        }

        private void Deposit()
        {

        }

        private void Withdraw()
        {

        }

        private void MonthlyDeposit()
        {

        }
    }
}