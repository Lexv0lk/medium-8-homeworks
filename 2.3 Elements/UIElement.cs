using System;

namespace _2._3_Elements
{
    abstract class UIElement
    {
        public int Height
        {
            get => Rect.Height;
            set
            {
                new Rect(Rect.X, Rect.Y, Rect.Width, value);
                _rectRenderer.Rect = Rect;
            }
        }

        public int Width
        {
            get => Rect.Width;
            set
            {
                Rect = new Rect(Rect.X, Rect.Y, value, Rect.Height);
                _rectRenderer.Rect = Rect;
            }
        }

        public string Text
        {
            get => _textRenderer.Text;
            set => _textRenderer.Text = value;
        }

        public int X => Rect.X;
        public int Y => Rect.Y;

        public Rect Rect { get; protected set; }
        protected RectRenderer _rectRenderer;
        protected TextRenderer _textRenderer;

        protected ConsoleColor _highlightedColor;

        public UIElement(int x, int y, ConsoleColor highlightedColor) : this(x, y)
        {
            _highlightedColor = highlightedColor;
        }

        public UIElement(int x, int y)
        {
            Rect = new Rect(x - 1, y - 1, 3, 3);
            _rectRenderer = new RectRenderer(Rect, '#');
            _textRenderer = new TextRenderer(X + 1, Y + 1, "");
            _highlightedColor = ConsoleColor.Yellow;
        }

        public abstract void Configurate();
        public abstract void Click();
        public abstract void Highlight();
        public abstract void OffHighlight();

        protected string GetElementName()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            string result = "";
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if(Width == 3)
                    {
                        Console.SetCursorPosition(Rect.X + 1, Rect.Y + 1);
                        if (result.Length != 0)
                        {
                            Console.Write(" ");
                            result = "";
                        }
                        Console.SetCursorPosition(Rect.X + 1, Rect.Y + 1);
                    }
                    else
                    {
                        _rectRenderer.Clear();
                        Width -= 1;
                        result = result.Remove(result.Length - 1, 1);
                        _rectRenderer.Render();
                    }
                   
                    keyInfo = Console.ReadKey();
                    continue;
                }

                _rectRenderer.Clear();
                if (result.Length > 0)
                    Width += 1;

                result += keyInfo.KeyChar;
                _textRenderer.Text = result;
                _textRenderer.Render();
                _rectRenderer.Render();
                keyInfo = Console.ReadKey();
            }

            return result;
        }
    }
}
