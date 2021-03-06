﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BankObjects
{
    class Bank
    {
        private string _bankname;
        private readonly List<BankAccount> _bankAccountsList;
        private readonly Random _rnd = new Random();

        public Bank(string bankName)
        {
            _bankname = bankName;
            _bankAccountsList = new List<BankAccount>();
        }

        public string CreateNewAccount(string firstName, string lastName)
        {
            string accountNumber = MakeRandomAccountNumber();

            BankAccount newBankAccount = new BankAccount(accountNumber);
            _bankAccountsList.Add(newBankAccount);

            return accountNumber;
        }

        public bool ClientMoneyTransfer(string accountNumber, double money, DateTime date)
        {
            BankAccount clientAccount = GetClientBankAccount(accountNumber);
            if (clientAccount == null)
                return false;

            clientAccount.MoneyActivity(money, date);
            return true;
        }

        public double GetClientMoney(string accountNumber)
        {
            BankAccount clientAccount = GetClientBankAccount(accountNumber);
            return clientAccount.Money;
        }

        public List<AccountActivity> GetClientActivitys(string accountNumber)
        {
            BankAccount clientAccount = GetClientBankAccount(accountNumber);
            List<AccountActivity> returnList = clientAccount.AccountActivityList;
            return returnList;
        }

        public List<AccountActivity> GetClientActivitys(string accountNumber, DateTime startDate, DateTime endDate)
        {
            BankAccount clientAccount = GetClientBankAccount(accountNumber);
            List<AccountActivity> returnList = clientAccount.GetActivitysSelectedList(startDate, endDate);
            return returnList;
        }


        // ***************************************************************************************************
        // private Functions 
        // ***************************************************************************************************

        private string MakeRandomAccountNumber()
        {
            string accountNumber = "FI";
            for (int i = 0; i < 16; i++)
            {
                int newNumber = _rnd.Next(10);
                accountNumber += newNumber;
            }
            return accountNumber;
        }

        private BankAccount GetClientBankAccount(string accountNumber)
        {
            BankAccount returnAccount = _bankAccountsList.FirstOrDefault(account => account.AccountNumber == accountNumber);
            if (returnAccount != null)
            {
                return returnAccount;
            }
            throw new Exception("Account number " + accountNumber + " not found");
        }

    }
}
