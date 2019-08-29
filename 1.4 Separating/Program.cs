using System;

namespace _1._4_Separating
{
    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        private Mover _mover;
        private Weapon _weapon;

        public Player(Mover mover, Weapon weapon)
        {
            _mover = mover;
            _weapon = weapon;
        }

        public void Move() => _mover.Move();
        public void Attack() => _weapon.Attack();
    }

    class Mover
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }

        public void Move()
        {
            //Do move
        }
    }

    class Weapon
    {
        public float WeaponCooldown { get; private set; }
        public int WeaponDamage { get; private set; }

        public void Attack()
        {
            //attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }
}
