using System;
using System.Collections.Generic;

namespace ATMDOTNET
{
    class Program
    {
        static void Authenticate(ref string user, ref string pass)
        {
            Console.WriteLine("ATM: Enter username");
            string username = Console.ReadLine();
            Console.WriteLine($"Enter password for {username}:");
            string password = Console.ReadLine();
            try
            {
                if (!ATM.Auth(username, password))
                {
                    throw new ArgumentException("Wrong Password");
                }
            }
            finally
            {
                user = username;
                pass = password;
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console
                    .WriteLine(@"
            Yaxis Bank ATM: Choose operations:
            1.    Create Account
            2.    Withdraw
            3.    Deposit
            4.    Transfer
            5.    View History
            6.    Watch Ads
            Press any other number to exit

            Enter your response number [1-6]");
                int choice = Convert.ToInt32(Console.ReadLine());
                string username = null;
                string password = null;
                decimal amount = 0;
                switch (choice)
                {
                    case 1:
                        {
                            string createdAccount = "";
                            try
                            {
                                Console.WriteLine("Enter new username");
                                username = Console.ReadLine();
                                Console.WriteLine("Enter new password");
                                password = Console.ReadLine();
                                createdAccount =
                                    ATM.AddAccount(username, password);
                                Console
                                    .WriteLine($"New account opened with username = " +
                                    createdAccount);
                            }
                            catch (ArgumentException)
                            {
                                Console
                                    .WriteLine("username already exists. Restarting Application..");
                            }
                            break;
                        }
                    case 2:
                        {
                            decimal balance = 0;
                            try
                            {
                                Authenticate(ref username, ref password);
                                Console.WriteLine("Enter Amount");
                                amount = Convert.ToDecimal(Console.ReadLine());
                                balance = ATM.Withdraw(username, amount);
                            }
                            catch (KeyNotFoundException)
                            {
                                Console
                                    .WriteLine("No user found with name " +
                                    username);
                            }
                            catch (ArgumentException)
                            {
                                Console
                                    .WriteLine("Entered Wrong Password. The police are waiting outside for you.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Enter valid number only");
                            }
                            catch (OverflowException)
                            {
                                Console
                                    .WriteLine("In your dreams. You dont have that much. The police are waiting outside for you.");
                            }
                            finally
                            {
                                Console
                                    .WriteLine("Transaction closed. Your balance = " +
                                    balance);
                            }
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        {
                            Console
                                .WriteLine("Thank you for keeping your cash money with Yaxis bank. Bye Bye.");
                            exit = true;
                        }
                        break;
                }
            }
        }
    }
}
