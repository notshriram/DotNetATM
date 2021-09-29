using System;
using System.Collections.Generic;

namespace ATMDOTNET
{
    public static class ATM
    {
        private static int transactionNumber;

        private static Dictionary<string, decimal> accounts;

        private static Dictionary<string, string> auth;

        private static Dictionary<string, List<string>> history;

        static ATM()
        {
            transactionNumber = 0;
            accounts = new Dictionary<string, decimal> { };
            auth = new Dictionary<string, string> { };
            history = new Dictionary<string, List<string>> { };
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
                history.Add(name, new List<string>());
            }
            finally
            {
                transactionNumber++;
                accounts[name] = 0;
                history[name]
                    .Add("Transaction Number " +
                    transactionNumber +
                    " : Created account");
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
                if (amount < 0)
                {
                    throw new FormatException();
                }
            }
            finally
            {
                transactionNumber++;
                accounts[name] -= amount;
                history[name]
                    .Add("Transaction Number " +
                    transactionNumber +
                    " : Withdrew " +
                    amount);
            }
            return accounts[name];
        }

        public static decimal Deposit(string name, decimal amount)
        {
            try
            {
                if (amount < 0)
                {
                    throw new FormatException();
                }
            }
            finally
            {
                transactionNumber++;
                accounts[name] += amount;
                history[name]
                    .Add("Transaction Number " +
                    transactionNumber +
                    " : Deposited " +
                    amount);
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
                transactionNumber++;
                accounts.Remove (name);
                auth.Remove (name);
                history.Remove (name);
            }
            return balance;
        }

        public static List<string> GetHistory(string name)
        {
            return history[name];
        }

        public static decimal CheckBalance(string name)
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
                if (amount < 0)
                {
                    throw new FormatException();
                }
                if (accounts[from] - amount < 0)
                {
                    throw new OverflowException("Insufficient funds");
                }
                if (!accounts.ContainsKey(to))
                {
                    throw new KeyNotFoundException("Recepient Name not found");
                }
            }
            finally
            {
                transactionNumber++;
                accounts[to] += amount;
                accounts[from] -= amount;
                history[from]
                    .Add("Transaction Number " +
                    transactionNumber +
                    " : Sent " +
                    amount +
                    " to " +
                    to);
                history[to]
                    .Add("Transaction Number " +
                    transactionNumber +
                    " : received " +
                    amount +
                    " from " +
                    from);
            }
            return accounts[from];
        }
    }
}
