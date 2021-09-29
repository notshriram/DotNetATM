using System;
using System.Collections.Generic;

namespace ATMDOTNET
{
    public static class ATM
    {
        private static Dictionary<string, decimal> accounts;

        private static Dictionary<string, string> auth;

        static ATM()
        {
            accounts = new Dictionary<string, decimal> { };
            auth = new Dictionary<string, string> { };
        }

        public static bool Auth(string username, string password)
        {
            return auth[username] == password;
        }

        public static string AddAccount(string name, string password)
        {
            try
            {
                accounts.Add(name, 0);
                auth.Add (name, password);
            }
            finally
            {
                accounts[name] = 0;
            }
            return name;
        }

        public static decimal Withdraw(string name, decimal amount)
        {
            try
            {
                if (accounts[name] - amount < 0)
                {
                    throw new OverflowException("No sufficient balance");
                }
            }
            finally
            {
                accounts[name] -= amount;
            }
            return accounts[name];
        }

        public static decimal Deposit(string name, decimal amount)
        {
            try
            {
                accounts[name] += amount;
            }
            finally
            {
            }

            return accounts[name];
        }

        public static decimal RemoveAccount(string name)
        {
            decimal balance = 0;
            try
            {
                balance = accounts[name];
            }
            finally
            {
                accounts.Remove (name);
                auth.Remove (name);
            }
            return balance;
        }

        public static decimal CheckBalance(string name, decimal amount)
        {
            try
            {
                accounts[name] += 0;
            }
            finally
            {
            }

            return accounts[name];
        }

        public static decimal Transfer(string from, string to, decimal amount)
        {
            try
            {
                if (accounts[from] - amount < 0)
                {
                    throw new ArgumentException("Insufficient funds");
                }
                if (!accounts.ContainsKey(to))
                {
                    throw new ArgumentException("Recepient Name not found");
                }
            }
            finally
            {
                accounts[to] += amount;
                accounts[from] -= amount;
            }
            return accounts[from];
        }
    }
}
