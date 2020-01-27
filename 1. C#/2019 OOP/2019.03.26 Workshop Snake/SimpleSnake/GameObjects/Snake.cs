using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int DefaultLength = 6;
        private const int DefaultX = 8;
        private const int DefaultY = 7;

        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeBody();
        }

        private void InitializeBody()
        {
            int x = DefaultX;
            int y = DefaultY;

            throw new NotImplementedException();
        }
    }
}
