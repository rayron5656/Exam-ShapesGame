using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_CC_Exem
{
    class TriangleMaker
    {
        static Random R = new Random();
        static int Size;
        static int X;
        static int Y;



        public static bool TriangleCheckForAvilableSpace(char[,] arraytocheck)
        {
            TriangleMaker.Size = R.Next(2, 9);
            TriangleMaker.X = R.Next(1,41);
            TriangleMaker.Y = R.Next(1,41);
            int temX = TriangleMaker.X;
            int temY = TriangleMaker.Y;
            int Xrep = 1;

            try
            {
                for (int i = 0; i < TriangleMaker.Size; i++)
                {
                    for (int j = 0; j < Xrep; j++)
                    {
                        if (arraytocheck[TriangleMaker.Y, TriangleMaker.X] != ' ')
                        {
                            GameManager.ResetTries++;
                            return false;
                        }
                        TriangleMaker.X++;

                    }
                    Xrep++;
                    TriangleMaker.Y++;
                }
                TriangleMaker.X = temX;
                TriangleMaker.Y = temY;


                return true;
            }
            catch (Exception)
            {
                GameManager.ResetTries++;
                return false;
            }
        }

        public static void DrawTriangle(ref char [,] arraytochange)
        {
            int temX = TriangleMaker.X;
            int temY = TriangleMaker.Y;
            int Xrep = 1;

            for (int i = 0; i < TriangleMaker.Size; i++)
            {
                for (int j = 0; j < Xrep; j++)
                {
                    arraytochange[TriangleMaker.Y, TriangleMaker.X] = '#';
                    TriangleMaker.X++;

                }
                TriangleMaker.X = temX;
                Xrep++;
                TriangleMaker.Y++;
            }
            
        }
    }
}
