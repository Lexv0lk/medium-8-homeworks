
namespace _2._2_Rallback
{
    class InputCommand
    {
        public readonly string Name;
        public readonly IAction Action;

        public InputCommand(string name, IAction action)
        {
            Name = name;
            Action = action;
        }
    }
}
