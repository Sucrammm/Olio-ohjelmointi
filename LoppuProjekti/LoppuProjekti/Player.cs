using System;
using KnightsQuest;


namespace KnightsQuest
{
    // Interface for items that can be equipped or consumed by the player
    public interface IItem
    {
        string Name { get; }
    }

    // Armor item that can be equipped by the player
    public class Armor : IItem
    {
        public string Name { get; private set; }
        public int Defense { get; private set; }

        public Armor(string name, int defense)
        {
            Name = name;
            Defense = defense;
        }

        public void Equip(Player player)
        {
            player.EquipArmor(this);
            Console.WriteLine($"Equipped {Name}");
        }
    }

    // Weapon item that can be equipped by the player
    public class Weapon : IItem
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void Equip(Player player)
        {
            player.EquipWeapon(this);
            Console.WriteLine($"Equipped {Name}");
        }
    }

    // Healing potion item that can be consumed by the player
    public class HealingPotion : IItem
    {
        public string Name { get; private set; }
        public int HealingAmount { get; private set; }

        public HealingPotion(string name, int healingAmount)
        {
            Name = name;
            HealingAmount = healingAmount;
        }

        // Heal the player
        public void Use(Player player)
        {
            player.Health += HealingAmount;
            Console.WriteLine($"Player heals {HealingAmount} health");
        }
    }
    public abstract class Player
    {
        // The player's health
        public int Health { get; set; } = 100;

        // The player's attack damage
        public int AttackDamage { get; set; } = 10;

        // The player's equipped armor
        public Armor EquippedArmor { get; set; }

        // The player's equipped weapon
        public Weapon EquippedWeapon { get; set; }

        public int Gold { get; set; }

        public List<Item> Inventory { get; set; }

        // Attack an enemy
        internal void Attack(Enemy enemy)
        {
            int damage = AttackDamage;

            // If the player has equipped armor, reduce the damage
            if (EquippedArmor != null)
            {
                damage -= EquippedArmor.Defense;
            }

            // If damage is negative, set it to 0
            damage = Math.Max(damage, 0);

            // Apply damage to the enemy
            enemy.TakeDamage(damage);
        }

        // Take damage from an enemy
        public void TakeDamage(int damage)
        {
            // If the player has equipped armor, reduce the damage
            if (EquippedArmor != null)
            {
                damage -= EquippedArmor.Defense;
            }

            // If damage is negative, set it to 0
            damage = Math.Max(damage, 0);

            Health -= damage;
            Console.WriteLine($"Player takes {damage} damage!");
        }

        public Player()
        {
            Health = 100;
            MaxHealth = 100;
            Attack = 10;
            Defense = 5;
            Gold = 0;
            Inventory = new List<Item>();
        }

        public bool IsDefeated
        {
            get { return Health <= 0; }
        }

        // Equip a piece of armor
        public void EquipArmor(Armor armor)
        {
            EquippedArmor = armor;
        }
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }
    }
}