using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_CC_Exem
{
    static class GameManager
    {
        static int NumberOfShapes;
        static public char[,] GameBoard;
        static public int Points = 0;
        static int counter = 0;
        static Random Rrep = new Random();
        static public int ResetTries = 0;
        static public bool UpMovement;
        public static int x = Rrep.Next(1, 41), y = Rrep.Next(1, 41);
        static bool LeftMovement = false;
        const char towrite = '*';
        static bool Firstset = true;
        static bool BstartLocation;
        







        public static void SetBoard(ref char[,] arraytoset)
        {
            if (Firstset)
            {
                NumberOfShapes = 3;
                arraytoset = new char[41, 41];
                for (int i = 0; i < 41; i++)
                {
                    for (int j = 0; j < 41; j++)
                    {
                        if (i == 0 && j == 40 || i == 40 && j == 0)
                        {
                            arraytoset[i, j] = '\\';
                        }
                        else if (i == 40 && j == 40 || i == 0 && j == 0)
                        {
                            arraytoset[i, j] = '/';
                        }
                        else if (i == 0 || i == 40)
                        {
                            arraytoset[i, j] = '-';
                        }
                        else if (j == 40 || j == 0)
                        {
                            arraytoset[i, j] = '|';
                        }
                        else
                        {
                            arraytoset[i, j] = ' ';
                        }
                    }
                }
                Firstset = false;
            }
            else
            {
                NumberOfShapes = 1;
                for (int i = 1; i < 40; i++)
                {
                    for (int j = 1; j < 40; j++)
                    {
                        if (GameBoard[i, j] == '|' || GameBoard[i, j] == '-')
                        {
                            GameBoard[i, j] = ' ';
                        }
                    }
                }
            }

            ResetTries = 0;

            while (GameManager.counter < GameManager.NumberOfShapes)
            {
                
                if (ResetTries < 30)
                {
                    int index = Rrep.Next(1, 4);
                    switch (index)
                    {

                        case 1:
                            if (LineMaker.LineCheckForOpenSpace(arraytoset))
                            {
                                LineMaker.DrawLine(ref arraytoset);
                                GameManager.counter++;
                                GameManager.ResetTries = 0;
                            }
                            break;
                        case 2:
                            if (SquareMaker.SqaureCheckForAvilableSpace(arraytoset))
                            {
                                
                                    SquareMaker.DrawSquare(ref arraytoset);
                                    GameManager.counter++;
                                    GameManager.ResetTries = 0;
                                

                            }
                            break;
                        case 3:
                            if (TriangleMaker.TriangleCheckForAvilableSpace(arraytoset))
                            {
                                TriangleMaker.DrawTriangle(ref arraytoset);
                                GameManager.counter++;
                                GameManager.ResetTries = 0;
                            }
                            break;

                    }
                }
                else
                {
                    break;
                }
                GameManager.startlocation();

            }
            counter = 0;

        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine($"Game over, your score is {GameManager.Points}");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        } //Good

        public static void NextMatch()
        {
            GameManager.SetBoard(ref GameBoard);

        }//Good

        public static void PrintBoard()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    Console.Write(GameManager.GameBoard[i, j]);
                }
                Console.WriteLine();
            }
        }//Good

        public static void PrintChar(int y, int x,char C)
        {
            GameManager.GameBoard[y, x] = C;
            Console.SetCursorPosition(x, y);
            
                Console.WriteLine(C);
            

            switch (GameManager.UpMovement)
            {
                case true:
                    GameManager.correctpassby(y,x+1);
                    break;
                case false:
                    GameManager.correctpassby(y,x+1);
                    break;
                    

            }
            Console.ForegroundColor = ConsoleColor.White;


        }//good

        public static bool CheckForstriks(int y,int x)
        {
            
            if (GameManager.GameBoard[y, x] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void correctpassby(int y,int x)
        {
            try
            {
                if (GameManager.GameBoard[y, x] != ' ')

                {
                    char C = GameManager.GameBoard[y, x];
                    if (x != 40)
                    {
                        switch (C)
                        {

                            case '|':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case '-':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                        }
                    }
                    else
                    {
                        switch (C)
                        {

                            case '|':
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case '-':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                        }
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write(GameManager.GameBoard[y, x]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception)
            {

                
            }
        }//good

        public static void startlocation()
        {
            if (ResetTries < 30)
            {
                if (GameBoard[GameManager.y, GameManager.x] == ' ')
                {
                    GameManager.MoveBall(towrite, GameManager.x, GameManager.y);
                    ResetTries = 0;
                    BstartLocation = true;
                }
                else
                {
                    GameManager.y = Rrep.Next(1, 41);
                    GameManager.x = Rrep.Next(1, 41);
                    ResetTries++;
                    BstartLocation = false;
                    
                }
            }
            else
            {
                EndGame();
            }

            
        }//Good

        public static void MoveBall(char towrite, int x, int y) //good
        {
            
            try
            {
                if (x >= 0 && y >= 0)
                {

                    Console.SetCursorPosition(x, y);
                    Console.Write(towrite);

                }
            }
            catch (Exception)
            {


            }
        }

        public static void Turn()
        {
            
                var command = Console.ReadKey().Key;

                switch (command)
                {
                    case ConsoleKey.UpArrow:
                        GameManager.UpMovement = true;

                        if (GameManager.y > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (LeftMovement)
                            {
                                GameManager.PrintChar(GameManager.y, GameManager.x + 1, '-');
                                Console.ForegroundColor = ConsoleColor.Blue;
                                GameManager.PrintChar(GameManager.y, GameManager.x, '|');
                                GameManager.y--;

                                LeftMovement = false;

                            }
                            else
                            {
                                GameManager.PrintChar(GameManager.y, GameManager.x, '|');
                                GameManager.y--;
                            }


                        }
                        break;
                    case ConsoleKey.DownArrow:
                        GameManager.UpMovement = false;

                        if (GameManager.y < 39)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (LeftMovement)
                            {
                                GameManager.PrintChar(GameManager.y, GameManager.x + 1, '-');
                                Console.ForegroundColor = ConsoleColor.Blue;
                                GameManager.PrintChar(GameManager.y, GameManager.x, '|');
                                GameManager.y++;


                                LeftMovement = false;
                            }
                            else
                            {
                                GameManager.PrintChar(GameManager.y, GameManager.x, '|');
                                GameManager.y++;
                            }

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (GameManager.x < 39)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;

                            GameManager.PrintChar(GameManager.y, GameManager.x, '-');
                            GameManager.x++;
                            LeftMovement = false;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (GameManager.x > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (LeftMovement)
                            {
                                LeftMovement = true;
                                GameManager.x--;
                                GameManager.PrintChar(GameManager.y, GameManager.x + 1, '-');
                                Console.ForegroundColor = ConsoleColor.Blue;
                                GameManager.PrintChar(GameManager.y, GameManager.x + 2, '-');
                            }
                            else
                            {
                                LeftMovement = true;
                                GameManager.x--;
                                GameManager.PrintChar(GameManager.y, GameManager.x + 1, '-');

                            }
                        }
                        break;
                }
                GameManager.MoveBall(towrite, GameManager.x, GameManager.y);


            
           
        }//good

        
    }
}
