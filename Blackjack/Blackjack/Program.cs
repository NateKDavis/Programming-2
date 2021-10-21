using BlackjackLibrary;
using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            string[] playAgainOption = new string[] { "yes", "no" };

            int userChoice = 0;
            while(userChoice != 3)
            {
                Console.Write("1. Play Blackjack\n2. Shuffle and Show Deck\n3. Exit\n");
                switch (Misc.ReadInteger("choice: ", 1, 3))
                {
                    case 1:
                        BlackjackGame game = new BlackjackGame();
                        int selection = 1;

                        while (selection == 1)
                        {
                            game.PlayRound();
                            Misc.ReadChoice("Would you like to play again? ", playAgainOption, out selection);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        deck.Shuffle();

                        for (int i = 0; i < 52; i++)
                        {
                            if (i % 7 == 0)
                            {
                                Console.WriteLine();
                            }

                            deck.Deal().Draw(Console.CursorLeft + 5, Console.CursorTop);
                        }

                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case 3:
                        userChoice = 3;
                        break;

                    default:
                        Console.WriteLine("How did you get here.... Press any key to return to the menu.");
                        Console.ReadKey();
                        break;
                }
            }

            // Clears console and centers exit message
            string exitMsg = "Thanks for playing! Press any key to exit...";
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - exitMsg.Length / 2, Console.WindowHeight / 2);
            Console.Write(exitMsg);
            Console.ReadKey();
        }        
    }
}
