using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_2._0
{
    class SnakeCell
    {
        public int x { get; set; }
        public int y { get; set; }
        //public bool isHead { get; set; }
        public string prevDirection { get; set; }
        public string direction { get; set; }
        public SnakeCell()
        {
        this.x = 7;
        this.y = 10;
        this.prevDirection ="right";
        this.direction = "null";
        }

        
        public SnakeCell(int x1,int y1,string direction, string prevDirection)
        {
         this.x = x1;
         this.y = y1;
         this.prevDirection = "right";
         this.direction = "null";
        }
       
        
        public void MoveOneCell(string direction)
        {
            if (direction == "left")
            {
                this.x--;
                this.direction = "left";
            }
            else if (direction == "up")
            {
                this.y--;
                this.direction = "up";
            }
            else if (direction == "down")
            {
                this.y++;
                this.direction = "down";
            }
            else if (direction == "right")
            {
                this.x++;
                this.direction = "right";
            }
            //this.prevDirection = direction;
            //prevDirection = direction;
            //this.direction = direction;
        }

        
        public void UpdateDirection()
        {
            prevDirection = direction;
        }
        
    }
}

