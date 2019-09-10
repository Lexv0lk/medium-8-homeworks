using System;

namespace _2._3_Elements
{
    class TextRenderer
    {
        public int X;
        public int Y;
        public string Text;

        public TextRenderer(int x, int y, string text)
        {
            X = x;
            Y = y;
            Text = text;
        }

        public void Render(ConsoleColor color)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Render();
            Console.ForegroundColor = lastColor;
        }

        public void Render()
        {
            int currentX = Console.CursorLeft;
            int currentY = Console.CursorTop;
            Console.CursorVisible = false;

            Console.SetCursorPosition(X, Y);
            Console.Write(Text);

            Console.CursorVisible = true;
            Console.SetCursorPosition(currentX, currentY);
        }
    }
}
