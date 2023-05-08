using System;

namespace KnightsQuest
{
    abstract class Enemy
    {
        // The enemy's health
        public int Health { get; set; } = 50;

        // The enemy's attack damage
        public int AttackDamage { get; set; } = 5;

        // The enemy's name
        public string Name { get; set; }

        // Whether the enemy is defeated
        public bool IsDefeated { get { return Health <= 0; } }

        public int Gold { get; set; }

        // The enemy attacks the player
        public abstract void Attack(Player player);

        // The enemy takes damage from the player
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage!");
        }
    }

    class Goblin : Enemy
    {
        public Goblin()
        {
            Name = "Goblin";
            Health = 20;
            AttackDamage = 5;
        }

        public override void Attack(Player player)
        {
            int damage = AttackDamage;
            Console.WriteLine($"The {Name} attacks you for {damage} damage!");

            // Apply damage to the player
            player.TakeDamage(damage);
        }
    }

    class Orc : Enemy
    {
        public Orc()
        {
            Name = "Orc";
            Health = 50;
            AttackDamage = 10;
        }

        public override void Attack(Player player)
        {
            int damage = AttackDamage;
            Console.WriteLine($"The {Name} attacks you for {damage} damage!");

            // Apply damage to the player
            player.TakeDamage(damage);
        }
    }

    class Dragon : Enemy
    {
        public Dragon()
        {
            Name = "Dragon";
            Health = 100;
            AttackDamage = 20;
        }

        public override void Attack(Player player)
        {
            int damage = AttackDamage;
            Console.WriteLine($"The {Name} attacks you for {damage} damage!");

            // Apply damage to the player
            player.TakeDamage(damage);
        }
    }
}
