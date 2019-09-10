using System;

namespace _2._3_Elements
{
    class CheckBox : UIElement
    {
        private bool _isHighlighted = false;

        public CheckBox(int x, int y, ConsoleColor highlightedColor) : base(x, y, highlightedColor)
        {

        }

        public CheckBox(int x, int y) : base(x, y)
        {

        }

        public override void Click()
        {
            if (_isHighlighted)
                OffHighlight();
            else
            {
                Highlight();
                _rectRenderer.Render();
            }
        }

        public override void Configurate()
        {
            _textRenderer.Text = "V";
            _textRenderer.Render();
            _rectRenderer.Render();
        }

        public override void Highlight()
        {
            _textRenderer.Render(_highlightedColor);
            _rectRenderer.Render(_highlightedColor);
            _isHighlighted = true;
        }

        public override void OffHighlight()
        {
            _rectRenderer.Render();
            _textRenderer.Render();
            _isHighlighted = false;
        }
    }
}
