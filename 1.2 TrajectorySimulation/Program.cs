using System;
using System.Collections.Generic;

namespace _1._2_TrajectorySimulation
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Object> objects = new List<Object>()
            {
                new Object(5, 5),
                new Object(10, 10),
                new Object(15, 15)
            };

            foreach (var obj in objects)
                obj.OnDead += () => objects.Remove(obj);

            while (true)
            {
                DetectCollisions(objects);
                MoveObjects(objects);
                RenderObjects(objects);
            }
        }

        private static void RenderObjects(List<Object> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                Console.SetCursorPosition(objects[i].X, objects[i].Y);
                Console.Write(i + 1);
            }
        }

        private static void MoveObjects(List<Object> objects)
        {
            Random random = new Random();

            foreach (var obj in objects)
            {
                obj.Move(random.Next(-1, 1), random.Next(-1, 1));
            }
        }

        private static void DetectCollisions(List<Object> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].IsDead)
                    continue;

                for (int j = 0; j < objects.Count; j++)
                {
                    if (j == i || objects[j].IsDead)
                        continue;

                    if (IsCollided(objects[i], objects[j]))
                    {
                        objects[i].OnCollision();
                        objects[j].OnCollision();
                    }
                }
            }
        }

        private static bool IsCollided(Object object1, Object object2) => object1.X == object2.X && object1.Y == object2.Y;
    }

    class Object
    {
        public bool IsDead => !_isAlive;

        public int X { get; private set; }
        public int Y { get; private set; }

        public event Action OnDead;

        private bool _isAlive = true;

        public Object(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int xDelta, int yDelta)
        {
            if (IsDead)
                return;

            X += xDelta;
            Y += yDelta;

            if (X < 0)
                X = 0;

            if (Y < 0)
                Y = 0;
        }

        public void OnCollision()
        {
            _isAlive = false;
            OnDead?.Invoke();
        }
    }
}
