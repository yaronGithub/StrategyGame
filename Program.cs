using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables

            // Piles of coins
            int A = 3;
            int B = 4;
            int C = 5;

            // player's pile choose
            char pile;
            // p stands for player
            string p1Name;
            string p2Name;
            // The player name who against the computer
            string p;

            int coins;

            // Game title
            Console.WriteLine("STRATEGY GAME\n");

            // Player decision to play against a computer or a real player
            Console.WriteLine("Play against a computer - 1. Play against a player - 2");
            int op = int.Parse(Console.ReadLine());
            Console.WriteLine();
            while (op != 1 && op != 2)
            {
                Console.WriteLine("Enter 1 or 2: ");
                op = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            // Against a real player
            if (op == 2)
            {
                Console.WriteLine("Player #1, enter your name: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                p1Name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPlayer #2, enter your name: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                p2Name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                // If the names are equal then the winner's name is unmeaningful
                while (p1Name == p2Name)
                {
                    Console.WriteLine("The names are equal. Please enter a different name: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    p2Name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }

                /*** GAME LOOP ***/
                while (A + B + C > 0)
                {
                    // Player #1 turn

                    printPiles(A, B, C);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n" + p1Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(", choose a pile: ");
                    pile = char.Parse(Console.ReadLine());
                    while ((pile != 'A' && pile != 'B' && pile != 'C') || ((pile == 'A' && A == 0) || (pile == 'B' && B == 0) || (pile == 'C' && C == 0)))
                    {
                        if (pile != 'A' && pile != 'B' && pile != 'C')
                        {
                            Console.WriteLine("Pile {0} does not exists. Please enter an existing pile: ", pile);
                            pile = char.Parse(Console.ReadLine());
                        }
                        else if (pile == 'A' && A == 0 || (pile == 'B' && B == 0) || pile == 'C' && C == 0)
                        {
                            Console.WriteLine("Pile {0} have 0 coins. Please enter a pile with coins: ", pile);
                            pile = char.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("How many coins would you like to remove from pile {0}:", pile);
                    Console.ForegroundColor = ConsoleColor.Green;
                    coins = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pile == 'A')
                    {
                        while (coins > A || coins == 0 || coins < 0)
                        {
                            if (coins > A)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile A. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        A -= coins;
                    }
                    else if (pile == 'B')
                    {
                        while (coins > B || coins == 0 || coins < 0)
                        {
                            if (coins > B)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile B. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        B -= coins;
                    }
                    else if (pile == 'C')
                    {
                        while (coins > C || coins == 0 || coins < 0)
                        {
                            if (coins > C)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile C. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        C -= coins;
                    }

                    // checking who is the winner
                    if (IsWinner(A, B, C))
                    {
                        printPiles(A, B, C);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n" + p2Name);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(", there are no counters left, so you WIN!");
                        break;
                    }
                    Console.WriteLine();


                    // Player #2 turn

                    printPiles(A, B, C);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n" + p2Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(", choose a pile: ");
                    pile = char.Parse(Console.ReadLine());
                    while ((pile != 'A' && pile != 'B' && pile != 'C') || ((pile == 'A' && A == 0) || (pile == 'B' && B == 0) || (pile == 'C' && C == 0)))
                    {
                        if (pile != 'A' && pile != 'B' && pile != 'C')
                        {
                            Console.WriteLine("Pile {0} does not exists. Please enter an existing pile: ", pile);
                            pile = char.Parse(Console.ReadLine());

                        }
                        else if (pile == 'A' && A == 0 || (pile == 'B' && B == 0) || pile == 'C' && C == 0)
                        {
                            Console.WriteLine("Pile {0} have 0 coins. Please enter a pile with coins: ", pile);
                            pile = char.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("How many coins would you like to remove from pile {0}:", pile);
                    coins = int.Parse(Console.ReadLine());

                    if (pile == 'A')
                    {
                        while (coins > A || coins == 0 || coins < 0)
                        {
                            if (coins > A)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile A. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        A -= coins;
                    }
                    else if (pile == 'B')
                    {
                        while (coins > B || coins == 0 || coins < 0)
                        {
                            if (coins > B)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile B. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        B -= coins;
                    }
                    else if (pile == 'C')
                    {
                        while (coins > C || coins == 0 || coins < 0)
                        {
                            if (coins > C)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile C. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        C -= coins;
                    }

                    // checking who is the winner
                    if (IsWinner(A, B, C))
                    {
                        printPiles(A, B, C);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n" + p1Name);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(", there are no counters left, so you WIN!");
                        break;
                    }
                    Console.WriteLine();
                }
            }
            // Against a computer - Smart or Dumb
            else
            {
                Console.WriteLine("Smart - 1. Dumb - 2.");
                int compLevel = int.Parse(Console.ReadLine());
                bool smart = false; // If the player does not choose 1 or 2 than the computer will be automatically dumb
                if (compLevel == 1)
                {
                    smart = true;
                }
                else if (compLevel == 2)
                {
                    smart = false;
                }
                Console.WriteLine("Enter your name: ");
                p = Console.ReadLine();

                /*** GAME LOOP ***/
                while (A + B + C > 0)
                {
                    // Player turn

                    printPiles(A, B, C);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\n" + p);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(", choose a pile: ");
                    pile = char.Parse(Console.ReadLine());
                    while ((pile != 'A' && pile != 'B' && pile != 'C') || ((pile == 'A' && A == 0) || (pile == 'B' && B == 0) || (pile == 'C' && C == 0)))
                    {
                        if (pile != 'A' && pile != 'B' && pile != 'C')
                        {
                            Console.WriteLine("Pile {0} does not exists. Please enter an existing pile: ", pile);
                            pile = char.Parse(Console.ReadLine());
                        }
                        else if (pile == 'A' && A == 0 || (pile == 'B' && B == 0) || pile == 'C' && C == 0)
                        {
                            Console.WriteLine("Pile {0} have 0 coins. Please enter a pile with coins: ", pile);
                            pile = char.Parse(Console.ReadLine());
                        }
                    }
                    Console.WriteLine("How many coins would you like to remove from pile {0}:", pile);
                    Console.ForegroundColor = ConsoleColor.Green;
                    coins = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pile == 'A')
                    {
                        while (coins > A || coins == 0 || coins < 0)
                        {
                            if (coins > A)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile A. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        A -= coins;
                    }
                    else if (pile == 'B')
                    {
                        while (coins > B || coins == 0 || coins < 0)
                        {
                            if (coins > B)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile B. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        B -= coins;
                    }
                    else if (pile == 'C')
                    {
                        while (coins > C || coins == 0 || coins < 0)
                        {
                            if (coins > C)
                            {
                                Console.WriteLine("The amount of coins is bigger then pile C. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins == 0)
                            {
                                Console.WriteLine("You have to take coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (coins < 0)
                            {
                                Console.WriteLine("You can't take negative amount of coins. Please enter a reasonable amount of coins: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                coins = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        C -= coins;
                    }

                    // checking who is the winner
                    if (IsWinner(A, B, C))
                    {
                        printPiles(A, B, C);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Computer won.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    Console.WriteLine();


                    // Computer turn
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Computer turn\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (ComputerPileOption(A, B, C, smart) == 'A')
                    {
                        int computerCoins = ComputerPlay(A, B, C, 'A', smart);
                        A -= computerCoins;
                        Console.WriteLine("The computer has taken {0} coins from pile A.", computerCoins);
                    }
                    else if (ComputerPileOption(A, B, C, smart) == 'B')
                    {
                        int computerCoins = ComputerPlay(A, B, C, 'B', smart);
                        B -= computerCoins;
                        Console.WriteLine("The computer has taken {0} coins from pile B.", computerCoins);
                    }
                    else if (ComputerPileOption(A, B, C, smart) == 'C')
                    {
                        int computerCoins = ComputerPlay(A, B, C, 'C', smart);
                        C -= computerCoins;
                        Console.WriteLine("The computer has taken {0} coins from pile C.", computerCoins);
                    }

                    // checking who is the winner
                    if (IsWinner(A, B, C))
                    {
                        printPiles(A, B, C);
                        Console.WriteLine();
                        Console.Write("\n" + p);
                        Console.WriteLine(", there are no counters left, so you WIN!");
                        break;
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void printPiles(int A, int B, int C)
        {
            /*
             * This method prints the piles graphically in the Console
             */
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A    B    C\n");
            for (int i = Math.Max(Math.Max(A, B), C); i >= 1; i--)
            {
                Console.Write(i <= A ? "$" : " ");
                Console.Write("    ");
                Console.Write(i <= B ? "$" : " ");
                Console.Write("    ");
                Console.Write(i <= C ? "$" : " ");
                Console.Write("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static bool IsWinner(int A, int B, int C)
        {
            /*
             * This method helps to find who is the winner by the rules of the game
             */
            if (A + B + C == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char ComputerPileOption(int A, int B, int C, bool smart)
        {
            /*
             * This method returns the computer's pile choose according the the rules of the game
             */
            int[] piles = { A, B, C };
            for (int i = 0; i < piles.Length; i++)
            {
                int sum;
                if (i == 0)
                {
                    sum = piles[1] + piles[2];
                }
                else if (i == 1)
                {
                    sum = piles[0] + piles[2];
                }
                else
                {
                    sum = piles[0] + piles[1];
                }
                if (piles[i] > 0)
                {
                    if (smart)
                    {
                        if ((int)(Math.Ceiling((Math.Log(sum) / Math.Log(2)))) == (int)(Math.Floor(((Math.Log(sum) / Math.Log(2))))))
                        {
                            if (i == 0)
                                return 'A';
                            if (i == 1)
                                return 'B';
                            if (i == 2)
                                return 'C';
                        }
                        else if (piles[i] == Math.Max(A, Math.Max(B, C)))
                        {
                            if (i == 0)
                                return 'A';
                            if (i == 1)
                                return 'B';
                            if (i == 2)
                                return 'C';
                        }
                    }
                    else // Dumb computer
                    {
                        if (i == 0)
                            return 'A';
                        if (i == 1)
                            return 'B';
                        if (i == 2)
                            return 'C';
                    }
                }
            }
            return 'e';
        }

        public static int ComputerPlay(int A, int B, int C, char pileOp, bool smart)
        {
            /*
             * This method returns the amount of coins which the computer takes after it chose a pile
             */
            int sub;
            if (pileOp == 'A')
            {
                if (smart)
                {
                    if (A > 1)
                    {
                        if ((B == 0 && C == 1) || (C == 0 && B == 1))
                        {
                            return A;
                        }
                        else if ((B == 0 && C > 1) || (C == 0 && B > 1))
                        {
                            return A - 2;
                        }
                        return A - 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    sub = new Random().Next(1, A + 1);
                    while (sub > A)
                    {
                        sub = new Random().Next(1, A + 1);
                    }
                    return sub;
                }
            }
            else if (pileOp == 'B')
            {
                if (smart)
                {
                    if (B > 1)
                    {
                        if ((C == 0 && A == 1) || (A == 0 && C == 1))
                        {
                            return B;
                        }
                        else if ((C == 0 && A > 1) || (A == 0 && C > 1))
                        {
                            return B - 2;
                        }
                        return B - 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    sub = new Random().Next(1, B + 1);
                    while (sub > B)
                    {
                        sub = new Random().Next(1, B + 1);
                    }
                    return sub;
                }
            }
            else if (pileOp == 'C')
            {
                if (smart)
                {
                    if (C > 1)
                    {
                        if ((B == 0 && A == 1) || (A == 0 && B == 1))
                        {
                            return C;
                        }
                        else if ((A == 0 && B > 1) || (B == 0 && A > 1))
                        {
                            return C - 2;
                        }
                        return C - 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    sub = new Random().Next(1, C + 1);
                    while (sub > C)
                    {
                        sub = new Random().Next(1, C + 1);
                    }
                    return sub;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
