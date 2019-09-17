using System;

namespace _2._4_1__Scenario
{
    class PageReader : IScenarioReader
    {
        public Page[] CurrentPages { get; private set; }
        private int _currentPageIndex = 0;

        public PageReader(Page[] pages)
        {
            SetPages(pages);
        }

        public void SetPages(Page[] pages)
        {
            CurrentPages = pages ?? throw new ArgumentNullException(nameof(pages));
            _currentPageIndex = 0;
        }

        public bool CanRead() => _currentPageIndex < CurrentPages.Length;

        public string[] ReadNext()
        {
            if (_currentPageIndex >= CurrentPages.Length)
                throw new IndexOutOfRangeException();

            return CurrentPages[_currentPageIndex++].TextLines;
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
