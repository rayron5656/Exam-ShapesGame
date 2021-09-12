using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_CC_Exem
{
    static class LineMaker
    {
        static Random R = new Random();
        static int Size;
        static int X;
        static int Y;




        static public bool LineCheckForOpenSpace(char[,] arraytocheck)
        {
            try
            {
                LineMaker.Size = R.Next(2, 10);
                LineMaker.X = R.Next(0,40);
                LineMaker.Y = R.Next(0,40);
                int tempX = LineMaker.X;
                
                for (int i = 0; i < LineMaker.Size; i++)
                {
                    if (arraytocheck[LineMaker.Y, LineMaker.X] != ' ')
                    {
                        GameManager.ResetTries++;
                        return false;
                    }


                    LineMaker.X += 1;
                }

                LineMaker.X = tempX;

                return true;
                
            }
            catch (Exception)
            {
                GameManager.ResetTries++;
                return false;
            }
        }

        static public void DrawLine(ref char[,] arraytochange)
        {
            for (int i = 0; i < LineMaker.Size; i++)
            {
                arraytochange[LineMaker.Y, LineMaker.X] = '=';


                LineMaker.X += 1;
            }

        }
    }
}
