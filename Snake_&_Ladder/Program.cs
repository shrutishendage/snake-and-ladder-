using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Second_Task_Snake___Ladder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Greet Message printed
            Console.WriteLine("Welcome to the Snake and Ladder Game Simulator!");
            Console.WriteLine("\nGame Starts Now\n");

            // Creating two Players
            Player playerOne = getPlayer(1);
            Player playerTwo = getPlayer(2);

            // Current Player playing the Game 
            Player currentPlayer = playerOne;

            // Intialize the Game 
            SnakeAndLadder snakeandladder = new SnakeAndLadder(currentPlayer, playerOne, playerTwo);

            Console.WriteLine($"\nName of the Current Player Playing is {snakeandladder.CurrentPlayer.Name}");
            Console.WriteLine($"Position of the Current Player Playing is {snakeandladder.CurrentPlayer.PlayerPosition}");

            // Terminating condition for the game 
            bool Win = false;

            // Check does anyone win till now
            while (!Win)
            {
                Console.WriteLine($"\nPlayer {snakeandladder.CurrentPlayer.Name}, press Enter to roll the die.. ");
                // Hold console for Player until press Enter 
                Console.ReadKey(true);

                // Move player after rolling the dice
                snakeandladder.MovePlayer(snakeandladder.CurrentPlayer);

                // Printing the state of the Board 
                snakeandladder.print();

                // Checking does anybody reached the winning position 
                if (snakeandladder.CheckWin())
                {
                    Console.WriteLine($"{snakeandladder.CurrentPlayer.Name} has won! Congratulations to you");
                    Win = true;
                    Console.WriteLine($"{snakeandladder.Count} times Dice was Roll");
                }

                // Swaping the player based on condition of Roll again 
                if (!snakeandladder.RollAgain)
                {
                    snakeandladder.CurrentPlayer = (snakeandladder.CurrentPlayer.Name.Equals(playerOne.Name)) ? playerTwo : playerOne;
                }
            }
        }


        // Utility Method which returns the player object 
        static Player getPlayer(int rank)
        {
            // loop to ask user again to input not null value 
            do
            {
                Console.Write("Enter the name of Player " + rank+" : ");
                string? player = Console.ReadLine();
                if (player is not null)
                {
                    return new Player(player);
                }
            }
            while (true);
        }
    }
}
