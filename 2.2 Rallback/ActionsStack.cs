using System.Collections.Generic;

namespace _2._2_Rallback
{
    class ActionsStack
    {
        private Stack<IAction> _lastActions = new Stack<IAction>();

        public void Execute(IAction action)
        {
            _lastActions.Push(action);
            action.Execute();
        }

        public void UndoLastAction()
        {
            if (_lastActions.Count == 0)
                return;

            IAction action = _lastActions.Pop();
            action.Undo();
        }
    }
}
