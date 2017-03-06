using System;

namespace BankObjects
{
    public class AccountActivity
    {
        private readonly DateTime _timeStamp;
        private readonly double _money;

        public AccountActivity( double money, DateTime date)
        {
            _timeStamp = date; 
            _money = money;
        }

        public DateTime TimeStamp => _timeStamp;

        public double Money => _money;

        public override string ToString()
        {
            return _timeStamp + " : " + _money;
        }
    }
}
