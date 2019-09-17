using System;
using System.Collections.Generic;
using System.Threading;

namespace _2._2_Rallback
{
    class TransferBetweenBalances : IAction
    {
        private BalancesDatabase _database;
        private BalancesUI _UI;

        private Stack<Transfer> _transfers = new Stack<Transfer>();

        public TransferBetweenBalances(BalancesDatabase database)
        {
            _database = database;
            _UI = new BalancesUI(_database);
        }

        public void Execute()
        {
            Console.Clear();

            _UI.Display(60, 0);
            Console.Write("Введите номер счёта отправителя: ");
            long senderId = long.Parse(Console.ReadLine());

            Console.Write("Введитель номер счёта получателя: ");
            long receiverId = long.Parse(Console.ReadLine());

            Console.Write("Введитель сумму: ");
            int value = int.Parse(Console.ReadLine());

            if(!isTransferValid(senderId, receiverId, value))
            {
                Console.Clear();
                _UI.Display(60, 0);
                Console.WriteLine("Операция некорректна!");
                Thread.Sleep(1500);
                return;
            }

            Balance sender = _database.Get(senderId);
            Balance receiver = _database.Get(receiverId);
            Transfer transfer = new Transfer(sender, receiver, value);
            sender.Distruct(value);
            receiver.Add(value);
            _transfers.Push(transfer);

            Console.Clear();
            _UI.Display(60, 0);
            Console.WriteLine("Операция прошла успешно");
            Thread.Sleep(1500);
        }

        private bool isTransferValid(long senderId, long receiverId, int value)
        {
            return _database.IsCountExists(senderId)
                && _database.IsCountExists(receiverId)
                && value <= _database.Get(senderId).Value;
        }

        public void Undo()
        {
            if (_transfers.Count == 0)
                return;

            Transfer lastTransfer = _transfers.Pop();
            lastTransfer.Sender.Add(lastTransfer.Value);
            lastTransfer.Receiver.Distruct(lastTransfer.Value);
        }
    }

    class Transfer
    {
        public readonly Balance Sender;
        public readonly Balance Receiver;
        public readonly int Value;

        public Transfer(Balance sender, Balance receiver, int value)
        {
            Sender = sender;
            Receiver = receiver;
            Value = value;
        }
    }
}
