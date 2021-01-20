using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Snake_2._0
{
    class Program
    {
        public static string direction = "";
        public static bool isSnake = false;
        public static int row { get; set; } = 25;
        public static int column { get; set; } = 50;
        //кортеж
        public static (int, int) GetAim()
        {
            var result = (0,0);
            Random rnd = new Random();
            result.Item1 = rnd.Next(1, (column-1));
            result.Item2 = rnd.Next(1, (row-1));
            return result;
        }

        public static void Show(int aimX, int aimY,int row,int column, List<SnakeCell> snakeList)
        {
            for (int row1 = 0;row1<=row;row1++)
            {
                for (int column1 = 0;column1<=column;column1++)
                {
                    if (row1 == 0 || row1 == row)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        if (column1 == 0 || column1 == column)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            isSnake = false;
                            snakeList.ForEach(delegate (SnakeCell snakecell)
                            {
                                if (row1 == snakecell.y && column1 == snakecell.x)
                                {
                                    Console.Write("s");
                                    isSnake = true;
                                }
                            });
                            if (isSnake == false)
                            {
                                if (column1 == aimX && row1 == aimY)
                                    Console.Write("O");
                                else
                                Console.Write(" ");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            //SnakeCell first = new SnakeCell();
            Snake snake = new Snake(10, 10,"null","right");

            int num = 0;
            var aim = GetAim();
            int aimX = aim.Item1;
            int aimY = aim.Item2;
            
            Show(aimX,aimY,row,column,snake.snakeList);
            while (num >= 0)
            {
                Console.WriteLine("Press the button");
                ConsoleKeyInfo pressButton = Console.ReadKey();
                snake.MoveSnake(pressButton);

                if (aimX == snake.snakeList.ElementAt(0).x && aimY == snake.snakeList.ElementAt(0).y)
                {
                    if(snake.snakeList.ElementAt(snake.snakeList.Count - 1).direction == "right")
                    {
                        snake.AddNewCell(snake.snakeList.ElementAt(snake.snakeList.Count - 1).x - 1, snake.snakeList.ElementAt(snake.snakeList.Count - 1).y, "null", "null");
                    }
                    if(snake.snakeList.ElementAt(snake.snakeList.Count - 1).direction == "left")
                    {
                        snake.AddNewCell(snake.snakeList.ElementAt(snake.snakeList.Count - 1).x + 1, snake.snakeList.ElementAt(snake.snakeList.Count - 1).y, "null", "null");
                    }
                    if(snake.snakeList.ElementAt(snake.snakeList.Count - 1).direction == "up")
                    {
                        snake.AddNewCell(snake.snakeList.ElementAt(snake.snakeList.Count - 1).x, snake.snakeList.ElementAt(snake.snakeList.Count - 1).y+1, "null", "null");
                    }
                    if(snake.snakeList.ElementAt(snake.snakeList.Count - 1).direction == "down")
                    {
                        snake.AddNewCell(snake.snakeList.ElementAt(snake.snakeList.Count - 1).x, snake.snakeList.ElementAt(snake.snakeList.Count - 1).y-1, "null", "null");
                    }
                    aim = GetAim();
                    aimX = aim.Item1;
                    aimY = aim.Item2;
                }
                if(snake.snakeList.ElementAt(0).x == column || snake.snakeList.ElementAt(0).y == row)
                {
                    Console.WriteLine("Game over");
                    break;
                }
                snake.UpdateSnake();
                Console.Clear();
                Show(aimX, aimY, row, column, snake.snakeList);
                num++;
            }            
            Console.ReadKey();
        }
    }
}
