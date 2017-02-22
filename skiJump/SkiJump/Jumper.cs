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

        ~Jumper()
        {

        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float points
        {
            get { return _points; }
            set { _points = value; }
        }

        public long id
        {
            get { return _id; }
            set { _id = value; }
        }


    }
}
