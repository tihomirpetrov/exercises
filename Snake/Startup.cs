namespace Snake
{
    using System;
    using System.Collections.Generic;
    using SnakeLibrary;
    class Startup
    {
        public static void Main()
        {
            SnakePosition[] directions = new SnakePosition[4]
            {
                new SnakePosition(0,1),
                new SnakePosition(0,-1),
                new SnakePosition(1,0),
                new SnakePosition(-1,0),
            };
            //SnakePosition right = new SnakePosition(0, 1);    
            //SnakePosition left = new SnakePosition(0, -1);    
            //SnakePosition down = new SnakePosition(1, 0);
            //SnakePosition up = new SnakePosition(-1, 0);
            //directions[0] = right;
            //directions[1] = left;
            //directions[2] = down;
            //directions[3] = up;

            int sleepTime = 100;
            int direction = 0;
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Random random = new Random();
            var row = random.Next(Console.WindowHeight);
            var col = random.Next(Console.WindowWidth);

            SnakePosition foodPosition = new SnakePosition(row, col);

            Console.SetCursorPosition(foodPosition.Col, foodPosition.Row);

            Console.Write('@');

            Queue<SnakePosition> snakeElements = new Queue<SnakePosition>();

            for (int i = 0; i < 3; i++)
            {
                snakeElements.Enqueue(new SnakePosition(0, i));
            }

            foreach (var position in snakeElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.Write('*');
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left)
                        {
                            direction = right;
                        }
                    }
                    else if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right)
                        {
                            direction = left;
                        }
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up)
                        {
                            direction = down;
                        }
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down)
                        {
                            direction = up;
                        }
                    }
                }

            }
            
        }
    }
}
