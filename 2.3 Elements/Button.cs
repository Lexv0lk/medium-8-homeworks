using System;
using System.Threading;

namespace _2._3_Elements
{
    class Button : TextField
    {
        public Button(int x, int y, ConsoleColor highlightedColor) : base(x, y, highlightedColor)
        {

        }

        public Button(int x, int y) : base(x, y)
        {

        }

        public override void Click()
        {
            Highlight();
            Thread.Sleep(500);
            OffHighlight();
        }
    }
}
