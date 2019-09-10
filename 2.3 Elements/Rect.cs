
namespace _2._3_Elements
{
    struct Rect
    {
        public readonly int X;
        public readonly int Y;
        public int Width;
        public int Height;

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width - 1
                && y >= Y && y <= Y + Height - 1;
        }

        public bool Contains(Rect rect)
        {
            return rect.X >= X && rect.X + rect.Width <= X + Width
                && rect.Y >= Y && rect.Y + rect.Height <= Y + Height;
        }
    }
}
