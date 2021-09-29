using System;
using System.Collections.Generic;

namespace ATMDOTNET
{
    public static class ATM
    {
        private static Dictionary<string, decimal> accounts;

        static ATM()
        {
            accounts = new Dictionary<string, decimal> { };
        }

        public static string AddAccount(string name)
        {
            try
            {
                accounts.Add(name, 0);
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
                    throw new ArgumentException("No sufficient balance");
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
