using System;

namespace ATMDOTNET
{
    class Program
    {
        static void Main(string[] args)
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
            
            Enter your response number [1-6]");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ATM: Enter username");
            string username = Console.ReadLine();
            Console.WriteLine($"Enter PIN for {username}:");
            string PIN = Console.ReadLine();
        }
    }
}
