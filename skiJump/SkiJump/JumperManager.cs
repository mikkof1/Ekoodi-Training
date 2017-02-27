using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkiJump
{
    class JumperManager
    {
        private List<Jumper> jumperList = new List<Jumper>();
        static long lastId = 88;

        public JumperManager()
        {

        }


        public List<Jumper> GetJumperList()
        {
            return jumperList;
        }


        public long AddNewJumper(Jumper newJumper)
        {
            newJumper.id = lastId;
            jumperList.Add(newJumper);
            lastId++;

            return lastId;
        }


        public bool ModifyJumper(Jumper modyfiedJumper)
        {
            int jumperListIndex = FindJumper(modyfiedJumper.id);
            if (jumperListIndex >= 0)
            {
                jumperList[jumperListIndex] = modyfiedJumper;
                return true;
            }
            return false;
        }


        public bool DeleteJumper(Jumper deleteJumper)
        {
            int jumperListIndex = FindJumper(deleteJumper.id);
            if (jumperListIndex >= 0)
            {
                jumperList.RemoveAt(jumperListIndex);
                return true;
            }
            return false;
        }

        private int FindJumper(long id)
        {
            int returnIndex = -1;
            int jumperListIndex = 0;
            foreach (Jumper jumper in jumperList)
            {
                if (jumper.id == id)
                {
                    returnIndex = jumperListIndex;
                    break;
                }
                jumperListIndex++;
            }
            return returnIndex;
        }



    }
}
