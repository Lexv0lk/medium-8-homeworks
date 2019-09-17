using System;

namespace _2._3_Elements
{
    class TextField : UIElement
    {
        private string _text;

        public TextField(int x, int y, ConsoleColor highlightedColor) : base(x, y, highlightedColor)
        {

        }

        public TextField(int x, int y) : base(x, y)
        {

        }

        public override void Click()
        {

        }

        public override void Configurate()
        {
            _rectRenderer.Render();

            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            Console.CursorVisible = true;
            Console.SetCursorPosition(X + 1, Y + 1);

            _text = GetElementName();
            _textRenderer.Text = _text;

            Console.SetCursorPosition(cursorX, cursorY);
        }

        public override void Highlight()
        {
            _rectRenderer.Render(_highlightedColor);
            _textRenderer.Render(_highlightedColor);           
        }

        public override void OffHighlight()
        {
            _rectRenderer.Render();
            _textRenderer.Render();
        }
    }
}
