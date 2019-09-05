using System;

abstract class Character
{
    public int Health;

    public void TakeDamage(int damage)
    {
        Health = ProcessDamage(damage);

        if (Health <= 0)
            Console.WriteLine("Я умер");
    }

    protected abstract int ProcessDamage(int damage);
}

class Wombat : Character
{
    public int Armor;

    protected override int ProcessDamage(int damage)
    {
        return damage - Armor;
    }
}

class Human : Character
{
    public int Agility;

    protected override int ProcessDamage(int damage)
    {
        return damage / Agility;
    }
}