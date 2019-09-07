using System.Collections.Generic;

namespace _2._2_Rallback
{
    class CommandsStack
    {
        private Stack<IAction> _lastActions = new Stack<IAction>();

        public void Execute(Command command)
        {
            _lastActions.Push(command.Action);
            command.Action.Execute();
        }

        public void UndoLastCommand()
        {
            if (_lastActions.Count == 0)
                return;

            IAction action = _lastActions.Pop();
            action.Undo();
        }
    }
}
