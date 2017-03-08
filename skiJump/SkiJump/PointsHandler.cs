using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiJump
{
    class PointsHandler
    {
        static private float _kPoint = 116;
        static private float _difficulity = 1.8f;
        static private float _stageHeight = 0;

        public PointsHandler()
        {

        }


        public void SetTowerDetalies(float kPoint, float difficulity, float stageHeight)
        {
            _kPoint = kPoint;
            _difficulity = difficulity;
            _stageHeight = stageHeight;
        }

        public float GetKPoint() { return _kPoint; }
        public float GetDifficulity() { return _difficulity; }
        public float GetStageHeight() { return _stageHeight; }

        public float CalculatePoints(float jumpLenght, float[] styleTable, float[] windTable)
        {
            float first = FirstPoints(jumpLenght);
            float style = StylePoints(styleTable);
            float wind = WindPoints(windTable);
            float stage = StagePoints();

            float summarium = first + style + wind - stage;

            var returnValue = summarium;
            return returnValue;
        }

        private float FirstPoints(float jumpLenght)
        {
            float points = 0;

            bool longJump = jumpLenght >= _kPoint;
            if (longJump)
            {
                float LONG_JUMP_EXTRA_POINTS = 60;
                float addLenght = jumpLenght - _kPoint;
                points = LONG_JUMP_EXTRA_POINTS + (addLenght * _difficulity);
            }
            return (float)Math.Round((decimal)points, 1);
        }

        private float StylePoints(float[] styleTable)
        {
            Array.Sort(styleTable);

            float points = 0;
            for (int i = 1; i < styleTable.Length - 1; i++)
            {
                points += styleTable[i];
            }

            return (float)Math.Round((decimal)points, 1);
        }


        private float WindPoints(float[] windTable)
        {
            float windSum = windTable.Sum();
            float windAvr = windSum / windTable.Length;

            decimal windDesimal = Math.Round((decimal)windAvr, 1);
            string[] windText = windDesimal.ToString().Split(',');
            int windInt = int.Parse(windText[0]);
            int firstDesimal = int.Parse(windText[1].Substring(0, 1));

            if (firstDesimal < 3)
            {
                windAvr = windInt;
            }
            if (firstDesimal >= 3 && firstDesimal < 7)
            {
                windAvr = windInt + 0.5f;
            }
            if (firstDesimal >= 7)
            {
                windAvr = windInt + 1;
            }

            float points = windAvr * (_kPoint - 36) / 20;


            return (float)Math.Round((decimal)points, 1);
        }


        private float StagePoints()
        {
            float points = _stageHeight * 5 * _difficulity;
            return (float)Math.Round((decimal)points, 1);
        }


    }
}
