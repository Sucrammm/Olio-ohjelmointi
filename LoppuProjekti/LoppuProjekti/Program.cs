using System;

namespace KnightsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Knight's Quest!");

            // Create a new instance of the Player class
            Player player = new Player();

            // Create a list of enemies
            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(new Goblin("Goblin"));
            enemies.Add(new Orc("Orc"));
            enemies.Add(new Dragon("Dragon"));

            // Create a new instance of the Shop class
            Shop shop = new Shop();

            // Loop until the player defeats the enemy
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Visit the shop");
                Console.WriteLine("2. Fight an enemy");
                Console.WriteLine("3. Quit the game");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                // Handle the player's choice
                switch (choice)
                {
                    case 1:
                        shop.Visit(player);
                        break;
                    case 2:
                        Console.WriteLine("Choose an enemy to fight:");

                        // Print the list of enemies
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {enemies[i].Name}");
                        }

                        // Ask the player to choose an enemy
                        Console.Write("Enter choice: ");
                        int enemyChoice = int.Parse(Console.ReadLine());

                        // Validate the enemy choice
                        if (enemyChoice < 1 || enemyChoice > enemies.Count)
                        {
                            Console.WriteLine("Invalid choice!");
                            continue;
                        }

                        // Start the battle
                        Battle(player, enemies[enemyChoice - 1]);
                        break;
                    case 3:
                        Console.WriteLine("Thanks for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                // Check if the enemy is defeated
                if (enemies.IsDefeated)
                {
                    Console.WriteLine($"You defeated the {enemies.Name}!");
                    Console.WriteLine($"You earned {enemies.Gold} gold!");
                    player.Gold += enemies.Gold;
                    return;
                }

                // Enemy attacks the player
                enemies.Attack(player);

                // Check if the player is defeated
                if (player.IsDefeated)
                {
                    Console.WriteLine("You were defeated by the enemy!");
                    Console.WriteLine($"You earned {player.Gold} gold!");
                    return;
                }
            }
            Console.WriteLine("Congratulations! You completed Knight's Quest!");
        }
    }

    public class Shop
    {
        private List<Item> items;

        public Shop()
        {
            items = new List<Item>();
            items.Add(new Item("Health Potion", 10, 50));
            items.Add(new Item("Sword", 100, 500));
            items.Add(new Item("Armor", 100, 500));
        }

        public void Visit(Player player)
        {
            Console.WriteLine("Welcome to the shop!");
            Console.WriteLine($"You have {player.Gold} gold.");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name} ({items[i].Price} gold)");
                }
                Console.WriteLine($"{items.Count + 1}. Leave the shop");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice < 1 || choice > items.Count + 1)
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                if (choice == items.Count + 1)
                {
                    Console.WriteLine("Thanks for shopping!");
                    break;
                }

                Item item = items[choice - 1];

                if (player.Gold < item.Price)
                {
                    Console.WriteLine("You don't have enough gold!");
                    continue;
                }

                player.Gold -= item.Price;
                Console.WriteLine($"You bought a {item.Name} for {item.Price} gold!");
                player.Inventory.Add(item);
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Value { get; set; }

        public Item(string name, int price, int value)
        {
            Name = name;
            Price = price;
            Value = value;
        }
    }

}