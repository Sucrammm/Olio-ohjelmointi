using System;

public class PingPong
{
    public static void Main()
    {
        int player1Score = 0;
        int player2Score = 0;
        string player1Name;
        string player2Name;

        Console.WriteLine("Welcome to Ping-Pong!");
        Console.WriteLine("Please enter the name of player 1:");
        player1Name = Console.ReadLine();
        Console.WriteLine("Please enter the name of player 2:");
        player2Name = Console.ReadLine();

        Console.WriteLine("Press Enter to start!");
        Console.ReadLine();

        while (player1Score < 21 && player2Score < 21)
        {
            int randomNumber = new Random().Next(1, 3);
            if (randomNumber == 1)
            {
                Console.WriteLine(player1Name + " scored!");
                player1Score++;
            }
            else
            {
                Console.WriteLine(player2Name + " scored!");
                player2Score++;
            }
            Console.WriteLine("The score is:");
            Console.WriteLine(player1Name + ": " + player1Score);
            Console.WriteLine(player2Name + ": " + player2Score);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        Console.WriteLine("The game is over! The final score is:");
        Console.WriteLine(player1Name + ": " + player1Score);
        Console.WriteLine(player2Name + ": " + player2Score);

        if (player1Score > player2Score)
            Console.WriteLine(player1Name + " won!");
        else
            Console.WriteLine(player2Name + " won!");
    }
}