using System;

namespace _2._3_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            RectRenderer rectRenderer = new RectRenderer(new Rect(0, 0, Console.WindowWidth, 20), '#');
            Cursor cursor = new Cursor(rectRenderer.Rect);
            UIBuilder UIBuilder = new UIBuilder(new Rect(rectRenderer.Rect.X + 1, rectRenderer.Rect.Y + 1, rectRenderer.Rect.Width - 2, rectRenderer.Rect.Height - 2));
            BuilderElementsList builderElementsList = new BuilderElementsList(UIBuilder);
            builderElementsList.Show();
            InputHandler inputHandler = new InputHandler(cursor, builderElementsList);

            WriteInfo();
            rectRenderer.Render();
            Console.SetCursorPosition(1, 1);

            while (true)
            {               
                inputHandler.Handle(GetInput());
            }
        }

        private static void WriteInfo()
        {
            Console.SetCursorPosition(Console.WindowWidth / 3, 22);
            Console.WriteLine("Arrows - Down menu navigation");
            Console.SetCursorPosition(Console.WindowWidth / 3, 24);
            Console.Write("AWSD - Main window navigation");
        }

        private static ConsoleKey GetInput()
        {
            int xCoord = Console.CursorLeft;
            int yCoord = Console.CursorTop;

            ConsoleKey key = Console.ReadKey(true).Key;
            Console.SetCursorPosition(xCoord, yCoord);

            return key;
        }
    }
}
