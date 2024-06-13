using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Snake___Ladder
{

    internal class SnakeAndLadder
    {
        // instances members representating state of Board
        public  int[] Board { get; set; } = new int[101];
        public readonly Player playerOne;
        public readonly Player playerTwo;
        public Player CurrentPlayer;
        public readonly Random random = new Random();
        public bool RollAgain { get; set; } = false;
        public int Count { get; set; } = 0;

        public SnakeAndLadder(Player currentPlayer, Player player1, Player player2)
        {
            CurrentPlayer = currentPlayer;
            playerOne = player1;
            playerTwo = player2;
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            // Define the positions of Board blocks
            for (int i = 1; i <= 100; i++)
            {

                Board[i] = i;
            }


            // Define the positions of snakes and ladders
            Board[6] = 040;
            Board[23] = -10;
            Board[45] = -07;
            Board[61] = -18;
            Board[65] = -08;
            Board[77] = 005;
            Board[98] = -10;

            print();
        }

        // method to roll the dice
        public int RollDie()
        {
            Count++;
            return random.Next(1, 7);
        }

        // method to ask for roll the dice and ask for new player position and print it
        public void MovePlayer(Player player)
        {
            int roll = RollDie();
            Console.WriteLine($"You rolled a {roll}.");
            player.PlayerPosition = MovePlayerPosition(player.PlayerPosition, roll);
            Console.WriteLine($"Player {player.Name} is now at square {player.PlayerPosition}.\n\n");
        }

        // method to actually move the player
        private int MovePlayerPosition(int currentPosition, int roll)
        {
            // stopping Player from going above 100 
            if (currentPosition + roll > 100)
                return currentPosition;

            // new position from currentposition of player and rolled Dice
            int newPosition = currentPosition + roll;

            // if player is on ladder position get another chance to roll the dice
            if (newPosition == 6 || newPosition == 77)
                RollAgain = true;
            else
                RollAgain = false;  

            // Declaring newSquare
            int newSquare;

            // adding or subtracting position when ladder or snake position reached
            if (newPosition == 6 || newPosition == 23 || newPosition == 45 || newPosition == 61 || newPosition == 77 || newPosition==98 || newPosition==65)
                newSquare = newPosition + Board[newPosition];
            else
                newSquare = newPosition;

            // returning newsquare or new position only when less than 100 otherwise sameposition
            return newSquare > 100 ? currentPosition : newSquare;
        }

        public void print()
        {

            int alt = 0; // to switch between the alternate nature of the board or rows
            int iterLR = 101; // iterator to print from left to right
            int iterRL = 80;  // iterator to print from right to left
            int val = 100;    // starting position top of the array 

            // creating space for better formatting
            Console.WriteLine();

            while (val-- > 0)
            {
                if (alt == 0)  
                {
                    iterLR--; // print from left to right in decreasing sequence
                    if (iterLR == playerOne.PlayerPosition)
                    {
                        Console.Write(playerOne.Name.Substring(0,3) + "    ");
                    }
                    else if (iterLR == playerTwo.PlayerPosition)
                    {
                        Console.Write(playerTwo.Name.Substring(0, 3) + "    ");
                    }
                    else 
                    {
                        if (iterLR == 23 || iterLR == 45 || iterLR == 61 || iterLR == 98 || iterLR == 65)
                            Console.Write(Board[iterLR].ToString("00") + "    ");
                        else
                            Console.Write(Board[iterLR].ToString("000") + "    ");
                    }

                    // check for the last digit is one
                    if (iterLR % 10 == 1)
                    {
                        Console.WriteLine("\n");
                        alt = 1;
                        iterLR -= 10;
                    }
                }
                else
                {
                    iterRL++;// print in increaseing sequence from right to left
                    if (iterRL == playerOne.PlayerPosition)
                    {
                        Console.Write(playerOne.Name.Substring(0, 3) + "    ");
                    }
                    else if (iterRL == playerTwo.PlayerPosition)
                    {
                        Console.Write(playerTwo.Name.Substring(0, 3) + "    ");
                    }
                    else
                    {
                        if (iterRL == 23 || iterRL == 45 || iterRL == 61 || iterRL == 98 || iterRL == 65)
                            Console.Write(Board[iterRL].ToString("00") + "    ");
                        else
                            Console.Write(Board[iterRL].ToString("000") + "    ");
                    }

                    // check for last digit is zero
                    if (iterRL % 10 == 0)
                    {
                        Console.WriteLine("\n");
                        alt = 0;
                        iterRL -= 30;
                    }
                }
                if (iterRL == 10) 
                    break;
            }
            Console.WriteLine();
        }

        public bool CheckWin()
        {
            return CurrentPlayer.PlayerPosition == 100;
        }
    }

    internal class Player(string name)
    {
        public string Name { get; set; } = name;

        public int PlayerPosition { get; set; } = 0;

    }
}


