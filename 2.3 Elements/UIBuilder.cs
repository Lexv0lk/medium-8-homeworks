using System;

namespace _2._3_Elements
{
    class UIBuilder
    {
        private Rect _buildWindow;

        public UIBuilder(Rect buildWindow)
        {
            _buildWindow = buildWindow;
        }

        public void BuildButton(int x, int y)
        {
            Button newButton = new Button(x, y);
            if (!CanBuildUIElement(newButton.Rect))
                return;
            
            BuildUIElement(newButton);
        }

        public void BuildCheckBox(int x, int y)
        {
            CheckBox newCheckBox = new CheckBox(x, y, ConsoleColor.Green);
            if (!CanBuildUIElement(newCheckBox.Rect))
                return;
        
            BuildUIElement(newCheckBox);
        }

        public void BuildTextField(int x, int y)
        {
            TextField newTextField = new TextField(x, y);
            if (!CanBuildUIElement(newTextField.Rect))
                return;

            BuildUIElement(newTextField);
        }

        private void BuildUIElement(UIElement element)
        {
            element.Configurate();
            UIStorage.Add(element);
        }

        private bool CanBuildUIElement(Rect elementRect)
        {
            if (!_buildWindow.Contains(elementRect))
                return false;

            if (UIStorage.GetUI(elementRect).Length != 0)
                return false;

            return true;
        }
    }
}
