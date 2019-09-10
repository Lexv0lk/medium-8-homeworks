using System;
using System.Collections.Generic;

namespace _2._3_Elements
{
    class BuilderElementsList
    {
        private List<BuildElement> _builderElements = new List<BuildElement>();
        private UIBuilder _builder;
        private int _currentElementsInd = 0;

        public BuilderElementsList(UIBuilder builder)
        {
            _builder = builder;
        }

        public void Show()
        {
            Button buttonSample = new Button(1, 23, ConsoleColor.Red);
            buttonSample.Width = 8;
            buttonSample.Text = "Button";
            buttonSample.OffHighlight();

            TextField textFieldSample = new TextField(10, 23, ConsoleColor.Red);
            textFieldSample.Width = 12;
            textFieldSample.Text = "Text Field";
            textFieldSample.OffHighlight();

            CheckBox checkboxSample = new CheckBox(23, 23, ConsoleColor.Red);
            checkboxSample.Configurate();
            checkboxSample.OffHighlight();

            _builderElements.Add(new BuildElement(buttonSample, (x, y) => _builder.BuildButton(x, y)));
            _builderElements.Add(new BuildElement(textFieldSample, (x, y) => _builder.BuildTextField(x, y)));
            _builderElements.Add(new BuildElement(checkboxSample, (x, y) => _builder.BuildCheckBox(x, y)));

            _builderElements[_currentElementsInd].UI.Highlight();
        }

        public void Next()
        {
            _builderElements[_currentElementsInd].UI.OffHighlight();

            _currentElementsInd++;
            if (_currentElementsInd >= _builderElements.Count)
                _currentElementsInd = 0;

            _builderElements[_currentElementsInd].UI.Highlight();
        }

        public void Previous()
        {
            _builderElements[_currentElementsInd].UI.OffHighlight();

            _currentElementsInd--;
            if (_currentElementsInd < 0)
                _currentElementsInd = _builderElements.Count - 1;

            _builderElements[_currentElementsInd].UI.Highlight();
        }

        public void BuildCurrentElement(int x, int y) => _builderElements[_currentElementsInd].Action?.Invoke(x, y);

        private class BuildElement
        {
            public readonly UIElement UI;
            public readonly Action<int, int> Action;

            public BuildElement(UIElement uI, Action<int, int> action)
            {
                UI = uI;
                Action = action;
            }
        }
    }
}
