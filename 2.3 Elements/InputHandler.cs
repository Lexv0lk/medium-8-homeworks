using System;

namespace _2._3_Elements
{
    class InputHandler
    {
        private Cursor _cursor;
        private UIBuilder _UIBuilder;
        private UserAction[] _movingActions;
        private UserAction[] _buildingActions;

        public InputHandler(Cursor cursor, UIBuilder UIBuilder)
        {
            _cursor = cursor;

            _movingActions = new[]
            {
                new UserAction(ConsoleKey.W, () => _cursor.Move(0, -1)),
                new UserAction(ConsoleKey.D, () => _cursor.Move(1, 0)),
                new UserAction(ConsoleKey.S, () => _cursor.Move(0, 1)),
                new UserAction(ConsoleKey.A, () => _cursor.Move(-1, 0))
            };
            _buildingActions = new[]
            {
                new UserAction(ConsoleKey.E, () => _UIBuilder.BuildButton(_cursor.X, _cursor.Y)),
                new UserAction(ConsoleKey.R, () => _UIBuilder.BuildTextField(_cursor.X, _cursor.Y)),
                new UserAction(ConsoleKey.T, () => _UIBuilder.BuildCheckBox(_cursor.X, _cursor.Y))
            };

            _UIBuilder = UIBuilder;
        }

        public void Handle(ConsoleKey key)
        {
            if (TryToMove(key))
                return;

            if (TryToClickUI(key))
                return;

            TryToBuildUI(key);
        }

        private bool TryToBuildUI(ConsoleKey key)
        {
            foreach (var buildingAction in _buildingActions)
            {
                if(key == buildingAction.Trigger)
                {
                    buildingAction.Execute();
                    return true;
                }
            }

            return false;
        }

        private bool TryToClickUI(ConsoleKey key)
        {
            if (key != ConsoleKey.Enter)
                return false;

            UIElement possibleElement = UIStorage.GetUI(_cursor.X, _cursor.Y);
            if (possibleElement == null)
                return false;

            possibleElement.Click();
            return true;
        }

        private bool TryToMove(ConsoleKey key)
        {
            foreach (var action in _movingActions)
                if(key == action.Trigger)
                {
                    action.Execute();
                    return true;
                }

            return false;
        }
    }
}
