using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_CC_Exem
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.SetBoard(ref GameManager.GameBoard);
            GameManager.PrintBoard();

            GameManager.startlocation();

            do
            {

                while (!GameManager.CheckForstriks(GameManager.y, GameManager.x))
                {

                    GameManager.Turn();
                    GameManager.Points++;

                }
                Console.Clear();
                GameManager.NextMatch();
                
                GameManager.PrintBoard();
                
            } while (GameManager.ResetTries < 30);

            GameManager.EndGame();

            












        }

       

    }
}
