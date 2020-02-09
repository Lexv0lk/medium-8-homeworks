using System;

namespace _2._2_Rallback
{
    class Program
    {
        private static BalancesDatabase _balancesDatabase = new BalancesDatabase();
        private static ActionsStack _actionsStack = new ActionsStack();

        private static void Main(string[] args)
        {
            ExecutableCommand[] commands = new[] { new ExecutableCommand("Открыть счёт", new BalanceOpening(_balancesDatabase)), new ExecutableCommand("Закрыть счёт", new BalanceClosing(_balancesDatabase)),
            new ExecutableCommand("Перевести деньги", new TransferBetweenBalances(_balancesDatabase))};
            BalancesUI UI = new BalancesUI(_balancesDatabase);

            while(true)
            {
                Console.Clear();
                UI.Display(50, 0);

                string input = GetCommandName();
                ProcessCommands(commands, input);
            }
        }

        private static string GetCommandName()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Введите команду: ");
            return Console.ReadLine();
        }

        private static void ProcessCommands(ExecutableCommand[] commands, string commandName)
        {
            commandName = commandName.ToLower();
            if(commandName == "undo")
            {
                _actionsStack.UndoLastAction();
                return;
            }

            foreach (var command in commands)
            {
                if(command.Name.ToLower() == commandName)
                {
                    _actionsStack.Execute(command.Action);
                    break;
                }
            }
        }
    }
}
