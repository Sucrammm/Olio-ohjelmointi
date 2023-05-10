using System;

namespace LoppuProjekti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa ritaripeliin!");

            Enemy örkki = new Örkki();
            Enemy trolli = new Trolli();
            Enemy lohikäärme = new Lohikäärme();
            
            Player player = new Player();

            Weapon hammer = new Weapon() { Name = "Vasara", Damage = 1 };
            Weapon Ring = new Weapon() { Name = "Sormus", Damage= 2 };
            Armor helmet = new Armor() { Name = "Kypärä", Defense = 5 };
            Armor shield = new Armor() { Name = "Kilpi", Defense = 7 };
          
            player.EquippedWeapon = hammer;
            player.EquippedWeapon = Ring;
            player.EquippedArmor = helmet;
            player.EquippedArmor = shield;

            List<Item> inventory = new List<Item>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Mitä aiot tehdä?");
                Console.WriteLine("1. Kauppa");
                Console.WriteLine("2. Hyökkää");
                Console.WriteLine("3. Inventory");
                Console.WriteLine("4. Lopeta peli");
                Console.Write("Valinta: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Olet kaupassa");

                    while (true)
                    {
                        Console.WriteLine($"Kulta määrä: {player.Money}");

                        Console.WriteLine("Mitä aiot tehdä?");
                        Console.WriteLine("");
                        Console.WriteLine("1. Kypärä (5 kultaa)");
                        Console.WriteLine("Kypärä antaa +5 hp");
                        Console.WriteLine("");
                        Console.WriteLine("2. HP potion (5 kultaa)");
                        Console.WriteLine("kun käytetty taistelussa lisää +20 hp");
                        Console.WriteLine("");
                        Console.WriteLine("3. Vasara (5 kultaa)");
                        Console.WriteLine("Antaa pelaajalle +1 dmg ja vähentää -2 hp");
                        Console.WriteLine("");
                        Console.WriteLine("4. Sormus (10 kultaa)");
                        Console.WriteLine("Lisää +2 ability dmg ja vähentää -2 hp");
                        Console.WriteLine("");
                        Console.WriteLine("5. Kilpi (10 kultaa)");
                        Console.WriteLine("Kilpi antaa +7 hp ja -2 dmg");
                        Console.WriteLine("");
                        Console.WriteLine("6. Takaisin");
                        Console.Write("Valinta: ");

                        int valinta = int.Parse(Console.ReadLine());
                        Console.WriteLine("");

                        if (valinta == 6)
                        {
                            break;
                        }

                        if (player.Money < 5)
                        {
                            Console.WriteLine("sinulla ei ole varaa siihen");
                        }

                        else
                        {
                            if (valinta == 1)
                            {
                                Console.WriteLine("Ostit kypärän ja sait +5 hp enemmän");
                                player.Health += 5;
                                player.Money -= 5;
                                inventory.Add(helmet);
                            }
                            if (valinta == 2)
                            {
                                Console.WriteLine("Ostit heltti potun");
                                player.pottu++;
                                player.Money -= 5;
                            }
                            if (valinta == 3)
                            {
                                Console.WriteLine("Ostit vasaran, sait +1 dmg ja vähensit -2 hp pelaajalta");
                                player.AttackDamage++;
                                player.Health -= 2;
                                player.Money -= 5;
                                inventory.Add(hammer);
                            }
                            if (valinta == 4)
                            {
                                Console.WriteLine("Ostit Sormuksen, lisäsit +2 ability dmg ja -2 hp");
                                player.AbilityDmg += 2;
                                player.Health -= 2;
                                player.Money -= 10;
                                inventory.Add(Ring);
                            }
                            if (valinta == 5)
                            {
                                Console.WriteLine("Ostit kilven, sait +10 hp ja -2 dmg");
                                player.Health += 10;
                                player.AttackDamage -= 2;
                                player.Money -= 10;
                                inventory.Add(shield);
                            }
                        }

                        if (valinta == 4)
                        {
                            continue;
                        }
                    }
                }

                else if (choice == 2)
                {
                    Enemy enemy;

                    Console.WriteLine("");
                    Console.WriteLine("Valitse vihollinen!");
                    Console.WriteLine("1. Örkki");
                    Console.WriteLine("2. Trolli");
                    Console.WriteLine("3. Lohikäärme");
                    Console.WriteLine("4. Takaisin");
                    Console.Write("Valinta: ");
                    int enemyChoice = int.Parse(Console.ReadLine());

                    if (enemyChoice == 1)
                    {
                        enemy = örkki;

                        while (!enemy.IsDefeated)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Pelaajan HP: {player.Health}");
                            Console.WriteLine($"Örkin HP: {enemy.Health}");

                            Console.WriteLine("Mitä aiot tehdä?");
                            Console.WriteLine("1. Hyökkää");
                            Console.WriteLine("2. Käytä ability");
                            Console.WriteLine($"3. Käytä HP potion (määrä: {player.pottu})");
                            Console.WriteLine("4. Pakene");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                case 2:
                                    player.UseAbility(enemy);
                                    break;
                                case 3:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($"Käytit heltti potun ja sait +20 hp. Sinulla on jäljellä {player.pottu} potiota.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("Sinulla ei ole HP potions");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("Pakenit taistelusta!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }

                            if (enemy.IsDefeated)
                            {
                                Console.WriteLine("Tapoit Örkki!");
                                player.Money += 5;
                                break;
                            }

                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Örkki tappoi sinut!");
                                return;
                            }
                        }
                    }

                    if (enemyChoice == 2)
                    {
                        enemy = trolli;

                        while (!enemy.IsDefeatedTro)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Pelaajan HP: {player.Health}");
                            Console.WriteLine($"Ritarin HP: {enemy.Trohealth}");

                            Console.WriteLine("Mitä aiot tehdä?");
                            Console.WriteLine("1. Hyökkää");
                            Console.WriteLine("2. Käytä ability");
                            Console.WriteLine($"3. Käytä HP potion (määrä: {player.pottu})");
                            Console.WriteLine("4. Pakene");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                case 2:
                                    player.UseAbility(enemy);
                                    break;
                                case 3:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($"Käytit heltti potun ja sait +20 hp. Sinulla on jäljellä {player.pottu} potiota.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("Sinulla ei ole HP potions");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("Pakenit taistelusta!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }

                            if (enemy.IsDefeatedTro)
                            {
                                Console.WriteLine("Tapoit Trollin!");
                                player.Money += 10;
                                break;
                            }

                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Trolli tappoi sinut!");
                                continue;
                            }
                        }
                    }

                    if (enemyChoice == 3)
                    {
                        enemy = lohikäärme;

                        while (!enemy.IsDefeatedloh)
                        {

                            Console.WriteLine();
                            Console.WriteLine($"Pelaajan HP: {player.Health}");
                            Console.WriteLine($"Lohikäärmeen HP: {enemy.Lohhealth}");

                            Console.WriteLine("Mitä aiot tehdä?");
                            Console.WriteLine("1. Hyökkää");
                            Console.WriteLine("2. Käytä ability");
                            Console.WriteLine($"3. Käytä HP potion (määrä: {player.pottu})");
                            Console.WriteLine("4. Pakene");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                case 2:
                                    enemy.IsWeakToAbility = true;

                                    player.UseAbility(enemy);
                                    break;
                                case 3:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($"Käytit heltti potun ja sait +20 hp. Sinulla on jäljellä {player.pottu} potions.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("Sinulla ei ole HP potions");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("Pakenit taistelusta!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }

                            if (enemy.IsDefeatedloh)
                            {
                                Console.WriteLine("Tapoit Lohikäärmeen!");
                                player.Money += 20;
                                break;
                            }

                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Lohikäärme tappoi sinut!");
                                continue;
                            }
                        }
                    }  
                    if (enemyChoice == 4)
                    {
                        continue;
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Inventory:");

                    if (inventory.Count == 0)
                    {
                        Console.WriteLine("Your inventory is empty.");
                    }
                    else
                    {
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Kiitos pelaamisesta!");
                    return;
                }
            }
        }
    }
}