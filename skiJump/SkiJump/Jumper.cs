using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiJump
{
    class Jumper
    {
        private string _name;
        private float _points;
        private long _id;

        public Jumper()
        {

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }


    }
}
