using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Snake_2._0
{
    class Snake
    {
        public List<SnakeCell> snakeList = new List<SnakeCell>();
        
        public Snake(int x, int y,string direction, string prevDirection)
        {
            for (int i = 0; i<5; i++)
            {
                AddNewCell(x - i, y,direction,prevDirection);
            }
        }

        public void AddNewCell(int x,int y,string direction ="null",string prevDirection="right")
        {
            snakeList.Add(new SnakeCell(x,y,direction,prevDirection));
        }

        public void MoveSnake(ConsoleKeyInfo pressButton)
        {
            //SnakeCell previous = new SnakeCell();
            this.snakeList.ForEach(delegate (SnakeCell snakeCell)
            {
                if (snakeList.IndexOf(snakeCell) == 0)
                {
                    if (pressButton.Key == ConsoleKey.RightArrow)
                    {
                        snakeCell.MoveOneCell("right");
                    }
                    else if (pressButton.Key == ConsoleKey.LeftArrow)
                    {
                        snakeCell.MoveOneCell("left");
                    }
                    else if (pressButton.Key == ConsoleKey.UpArrow)
                    {
                        snakeCell.MoveOneCell("up");
                    }
                    else if (pressButton.Key == ConsoleKey.DownArrow)
                    {
                        snakeCell.MoveOneCell("down");
                    }
                }
                else
                {
                    snakeCell.MoveOneCell(snakeList[(snakeList.IndexOf(snakeCell)) - 1].prevDirection);
                }
            });
        }


        public void UpdateSnake()
            {
            this.snakeList.ForEach(delegate (SnakeCell snakeCell)
                {
                    snakeCell.UpdateDirection();
                });

            }
        
    }
}
