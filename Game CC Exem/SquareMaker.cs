using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_CC_Exem
{
    static class SquareMaker
    {
        static Random R = new Random();
        static int Size;
        static int X;
        static int Y;



        public static bool SqaureCheckForAvilableSpace(char[,] arraytocheck)
        {
            SquareMaker.Size = R.Next(3,10);
            SquareMaker.X = R.Next(1,41);
            SquareMaker.Y = R.Next(1,41);
            int temX = SquareMaker.X;
            int temY = SquareMaker.Y;

            try
            {
                for (int i = 0; i < SquareMaker.Size; i++)
                {
                    for (int j = 0; j < SquareMaker.Size; j++)
                    {
                        if (arraytocheck[SquareMaker.Y, SquareMaker.X] != ' ')
                        {
                            GameManager.ResetTries++;
                            return false;
                        }
                        SquareMaker.X++;
                    }
                    SquareMaker.Y++;
                    SquareMaker.X = temX;
                }
                SquareMaker.Y = temY;
                SquareMaker.X = temX;

                return true;
            }
            catch (Exception)
            {
                GameManager.ResetTries++;
                return false;
            }

        }

        public static void DrawSquare(ref char [,] arraytochange)
        {
            int temX = SquareMaker.X;
            int temY = SquareMaker.Y;

            for (int i = 0; i < SquareMaker.Size; i++)
            {
                for (int j = 0; j < SquareMaker.Size; j++)
                {
                    arraytochange[SquareMaker.Y, SquareMaker.X] = 'ם';
                    SquareMaker.X++;
                }
                SquareMaker.X = temX;
                SquareMaker.Y++;
            }
        }
    }
}
