using System;

namespace _2._4_1__Scenario
{
    class PageReader : IScenarioReader
    {
        public Page[] Pages { get; private set; }
        private int _currentPageIndex = 0;

        public PageReader(Page[] pages)
        {
            SetPages(pages);
        }

        public void SetPages(Page[] pages)
        {
            Pages = pages ?? throw new ArgumentNullException(nameof(pages));
            _currentPageIndex = 0;
        }

        public bool CanRead() => _currentPageIndex < Pages.Length;

        public string[] ReadNext()
        {
            if (_currentPageIndex >= Pages.Length)
                throw new IndexOutOfRangeException();

            return Pages[_currentPageIndex++].TextLines;
        }
    }

    class Page
    {
        public string[] TextLines { get; }

        public Page(string[] text)
        {
            TextLines = text;
        }
    }
}
