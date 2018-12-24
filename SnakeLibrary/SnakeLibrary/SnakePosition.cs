namespace SnakeLibrary
{
    using System;
    public class SnakePosition
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public SnakePosition(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}