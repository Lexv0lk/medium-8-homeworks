
namespace _2._2_Rallback
{
    class ExecutableCommand
    {
        public readonly string Name;
        public readonly IAction Action;

        public ExecutableCommand(string name, IAction action)
        {
            Name = name;
            Action = action;
        }
    }
}
