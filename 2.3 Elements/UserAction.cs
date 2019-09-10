using System;

namespace _2._3_Elements
{
    class UserAction
    {
        public readonly ConsoleKey Trigger;
        private Action _action;

        public UserAction(ConsoleKey trigger, Action action)
        {
            Trigger = trigger;
            _action = action;
        }

        public void Execute() => _action?.Invoke();
    }
}
