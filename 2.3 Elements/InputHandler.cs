using System;

namespace _2._3_Elements
{
    class InputHandler
    {
        private Cursor _cursor;
        private BuilderElementsList _builderElementsList;
        private UserAction[] _movingActions;

        public InputHandler(Cursor cursor, BuilderElementsList builderElementsList)
        {
            _cursor = cursor;
            _movingActions = new[]
            {
                new UserAction(ConsoleKey.W, () => _cursor.Move(0, -1)),
                new UserAction(ConsoleKey.D, () => _cursor.Move(1, 0)),
                new UserAction(ConsoleKey.S, () => _cursor.Move(0, 1)),
                new UserAction(ConsoleKey.A, () => _cursor.Move(-1, 0)),
                new UserAction(ConsoleKey.LeftArrow, () => _builderElementsList.Previous()),
                new UserAction(ConsoleKey.RightArrow, () => _builderElementsList.Next())
            };
            _builderElementsList = builderElementsList;
        }

        public void Handle(ConsoleKey key)
        {
            if (TryToMove(key))
                return;

            if (TryToClickUI(key))
                return;

            if (key == ConsoleKey.Enter)
                _builderElementsList.BuildCurrentElement(_cursor.X, _cursor.Y);
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
