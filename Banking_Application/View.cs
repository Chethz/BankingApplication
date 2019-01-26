using System;
using System.Collections.Generic;

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
            while (true)
            {
                Console.WriteLine("\n-----Creating Customer----");
                Console.Write("Enter First Name : ");
                string firstName = Console.ReadLine().Trim();
                Console.Write("Enter Last Name : ");
                string lastName = Console.ReadLine().Trim();
                Console.Write("Enter Address : ");
                string address = Console.ReadLine().Trim();
                Console.Write("Enter Date of birth : ");
                string dob = Console.ReadLine().Trim();
                Console.Write("Enter Contact : ");
                string contact = Console.ReadLine().Trim();
                Console.Write("Enter Email : ");
                string email = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine().ToUpper().Trim();

                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.AddCustomer(firstName, lastName, address, dob, contact, email);
                        Console.WriteLine("Customer has been created successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void SearchCustomer()
        {
            while (true)
            {
                Console.WriteLine("\n-----Search Customer----");
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write("Enter Last Name : ");
                string lastName = Console.ReadLine().Trim();
                Console.Write("Enter Address : ");
                string address = Console.ReadLine().Trim();
                Console.Write("Enter Date of birth : ");
                string dob = Console.ReadLine().Trim();
                Console.Write("Enter Contact : ");
                string contact = Console.ReadLine().Trim();
                Console.Write("Enter Email : ");
                string email = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine().ToUpper().Trim();
                if (option == "S")
                {
                    try
                    {
                        DisplaySearchResuarlt(_BankingSystem.SearchCustomers(firstName, lastName, address, dob, contact, email));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        
        // Displaying search results of customer search
        private void DisplaySearchResuarlt(List<Customer> results)
        {
            Console.WriteLine("Search results:");
            foreach (Customer customer in results)
                Console.WriteLine(customer.ToString());
            Console.WriteLine("\nPress any keys to go back to Main menu");
            Console.ReadLine();
        }

        private void OpenAccount()
        {
            while (true)
            {
                Console.WriteLine("\n--------Open Account-------");
                Console.Write("Enter Owner ID : ");
                string ownerID = Console.ReadLine().Trim();
                Console.Write("Enter Account Type : ");
                string accountType = Console.ReadLine().Trim();
                Console.Write("Enter Intial Balance : ");
                string balance = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine().ToUpper().Trim();
                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.AddAccount(ownerID, accountType, balance);
                        Console.WriteLine("An account has been opened successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }

        private void SearchAccount()
        {
            while (true)
            {
                Console.WriteLine("\n--------Search Account-------");
                Console.Write("Enter Account ID: ");
                string accountID = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine();
                if (option == "S")
                {
                    try
                    {
                        DisplayAccountSearchResult(_BankingSystem.SearchAccount(accountID));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }
        
        // Displaying search result of account search
        private void DisplayAccountSearchResult(Account result)
        {
            Console.WriteLine("Search results:");
            Console.WriteLine(result.ToString());
            Console.WriteLine("\nPress any keys to go back to Main menu");
            Console.ReadLine();
        }

        private void Transfer()
        {
            while (true)
            {
                Console.WriteLine("\n------------Transfer------------");
                Console.Write("Enter Source Account ID : ");
                string sourceAccountID = Console.ReadLine().Trim();
                Console.Write("Enter Destination Account ID : ");
                string destinationAccountID = Console.ReadLine().Trim();
                Console.Write("Enter Amount : ");
                string amount = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine();
                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.Transfer(sourceAccountID, destinationAccountID, amount);
                        Console.WriteLine("Transaction has been done successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }

        private void Deposit()
        {
            while (true)
            {
                Console.WriteLine("\n------------Deposit------------");
                Console.Write("Enter Account ID : ");
                string accountID = Console.ReadLine().Trim();
                Console.Write("Enter Amount : ");
                string amount = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option: ");
                string option = Console.ReadLine();
                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.Deposit(accountID, amount);
                        Console.WriteLine("Transaction has been done successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }

        private void Withdraw()
        {
            while (true)
            {
                Console.WriteLine("\n------------Withdraw------------");
                Console.Write("Enter Account ID : ");
                string accountID = Console.ReadLine().Trim();
                Console.Write("Enter Amount : ");
                string amount = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option : ");
                string option = Console.ReadLine();
                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.Withdraw(accountID, amount);
                        Console.WriteLine("Transaction has been done successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }

        private void MonthlyDeposit()
        {
            while (true)
            {
                Console.WriteLine("\n------------Monthly Deposit------------");
                Console.Write("Enter Account ID : ");
                string accountID = Console.ReadLine().Trim();
                Console.Write("Enter Monthly Deposit : ");
                string monthlyDeposit = Console.ReadLine().Trim();
                Console.WriteLine("Press 's' or 'S' if you want to submit");
                Console.WriteLine("Press any other keys if you want to cancel");
                Console.Write("Your option : ");
                string option = Console.ReadLine();
                if (option == "S")
                {
                    try
                    {
                        _BankingSystem.SetMonthlyDeposit(accountID, monthlyDeposit);
                        Console.WriteLine("Transaction has been done successfully!");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    break;
            }
        }
    }
}