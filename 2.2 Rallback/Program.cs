using System;

namespace _2._2_Rallback
{
    class Program
    {
        private static CountsDatabase _countDatabase = new CountsDatabase();
        private static CommandsStack _commandsStack = new CommandsStack();

        private static void Main(string[] args)
        {
            Command[] commands = new[] { new Command("Открыть счёт", new CountOpening(_countDatabase)), new Command("Закрыть счёт", new CountClosing(_countDatabase)),
            new Command("Перевести деньги", new TransferBetweenCounts(_countDatabase))};
            CountsUI UI = new CountsUI(_countDatabase);

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

        private static void ProcessCommands(Command[] commands, string commandName)
        {
            commandName = commandName.ToLower();
            if(commandName == "undo")
            {
                _commandsStack.UndoLastCommand();
                return;
            }

            foreach (var command in commands)
            {
                if(command.Name.ToLower() == commandName)
                {
                    _commandsStack.Execute(command);
                    break;
                }
            }
        }
    }
}
