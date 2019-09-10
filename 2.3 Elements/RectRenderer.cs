using System;

namespace _2._3_Elements
{
    class RectRenderer
    {
        public Rect Rect;
        public char SymbolToRender;

        public RectRenderer(Rect rect, char symbolToRender)
        {
            Rect = rect;
            SymbolToRender = symbolToRender;
        }

        public void Render(ConsoleColor lettersColor)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = lettersColor;
            Render();
            Console.ForegroundColor = lastColor;
        }

        public void Render()
        {
            Clear();
            Render(SymbolToRender);
        }

        private void Render(char symbol)
        {           
            int lastX = Console.CursorLeft;
            int lastY = Console.CursorTop;
            Console.CursorVisible = false;

            for (int i = 0; i < Rect.Width; i++)
            {
                for (int j = 0; j < Rect.Height; j++)
                {
                    if (i == 0 || j == 0 || i == Rect.Width - 1 || j == Rect.Height - 1)
                    {
                        Console.SetCursorPosition(Rect.X + i, Rect.Y + j);
                        Console.Write(symbol);
                    }
                }
            }

            Console.SetCursorPosition(lastX, lastY);
            Console.CursorVisible = true;
        }

        public void Clear() => Render(' ');
    }
}
