using System;

namespace LoppuProjekti
{
    abstract class Item
    {
        public string Name { get; set; }
    }

    class Weapon : Item
    {
        public int Damage { get; set; }
    }

    class Armor : Item
    {
        public int Defense { get; set; }
    }
    class Player
    {
        public int Health { get; set; } = 100;
        public int AttackDamage { get; set; } = 10;
        public int AbilityCooldown { get; set; } = 3;
        private int abilityCooldownRemaining = 0;
        public int AbilityDmg { get; set; } = 0;
        public int Money { get; set; } = 0;
        public int pottu { get; set; } = 0;
        private Random random = new Random();
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }

        public void Attack(Enemy enemy)
        {
            int damage = random.Next(5, 11);
            if (EquippedWeapon != null)
            {
                damage += EquippedWeapon.Damage;
            }
            enemy.TakeDamage(damage);
            Console.WriteLine($"Pelaaja hyökkää ja tekee {damage} vahinkoa!");
        }

        public void UseAbility(Enemy enemy)
        {
            if (abilityCooldownRemaining > 0)
            {
                Console.WriteLine("Abilityssäsi on vielä cooldown!");
                return;
            }

            int AbilityDmg = AttackDamage * 2;
            Console.WriteLine($"sinä käytät abilitysi viholliseen ja teet {AbilityDmg} damagea!");

            enemy.TakeDamage(AbilityDmg);

            abilityCooldownRemaining = AbilityCooldown;
        }

        public void TakeDamage(int damage)
        {
            if (EquippedWeapon != null)
            {
                damage += EquippedWeapon.Damage;
            }

            Health -= damage;
            Console.WriteLine($"sinä otat {damage} damagea vihulta!");
        }
    }
}