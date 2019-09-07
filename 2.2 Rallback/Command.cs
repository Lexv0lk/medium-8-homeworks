
namespace _2._2_Rallback
{
    class Command
    {
        public readonly string Name;
        public readonly IAction Action;

        public Command(string name, IAction action)
        {
            Name = name;
            Action = action;
        }

        public void Execute() => Action.Execute();
    }
}
