using System.Collections.Generic;

namespace _2._3_Elements
{
    static class UIStorage
    {
        private static List<UIElement> _elements = new List<UIElement>();

        public static void Add(UIElement element) => _elements.Add(element);

        public static UIElement GetUI(int x, int y)
        {
            foreach (var element in _elements)
                if (element.Rect.Contains(x, y))
                    return element;

            return null;
        }

        public static UIElement[] GetUI(Rect square)
        {
            List<UIElement> result = new List<UIElement>();
            for (int i = square.X; i < square.Width + square.X; i++)
                for (int j = square.Y; j < square.Height + square.Y; j++)
                {
                    UIElement target = GetUI(i, j);
                    if (target == null)
                        continue;

                    if (!result.Contains(target))
                        result.Add(target);
                }

            return result.ToArray();
        }
    }
}
