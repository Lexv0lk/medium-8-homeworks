using System;

namespace _2._3_Elements
{
    class Cursor
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Rect _availableRect;

        public Cursor(Rect availableRect)
        {
            _availableRect = availableRect;
        }

        public void Move(int xDelta, int yDelta)
        {
            int newX = Console.CursorLeft + xDelta;
            int newY = Console.CursorTop + yDelta;

            if (IsInWidthOfWindow(newX) && IsInHeightOfWindow(newY))
            {
                X = newX;
                Y = newY;
                Console.SetCursorPosition(X, Y);               
            }
        }

        private bool IsInWidthOfWindow(int coord) => coord > _availableRect.X && coord < _availableRect.X + _availableRect.Width - 1;
        private bool IsInHeightOfWindow(int coord) => coord > _availableRect.Y && coord < _availableRect.Y + _availableRect.Height - 1;
    }
}
