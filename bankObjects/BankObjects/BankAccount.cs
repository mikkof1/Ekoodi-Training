using System;
using System.Collections.Generic;
using System.Linq;

namespace BankObjects
{
    public class BankAccount
    {
        private readonly List<AccountActivity> _accountActivityList;
        private double _money;

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            _accountActivityList = new List<AccountActivity>();
        }

        public string AccountNumber { get; }

        public List<AccountActivity> AccountActivityList => _accountActivityList;

        public double Money => _money;

        public void MoneyActivity(double money, DateTime date)
        {
            _money = _money + money;
            AccountActivity activity = new AccountActivity(money, date);
            _accountActivityList.Add(activity);
        }

        public List<AccountActivity> GetActivitysSelectedList(DateTime startDate, DateTime endDate)
        {
            return _accountActivityList.FindAll(a => a.TimeStamp >= startDate && a.TimeStamp <= endDate).ToList();
        }


    }
}
