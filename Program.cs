using System;

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
                switch (choice)
                {
                    case 1:
                        {
                            string username;
                            string password;
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
