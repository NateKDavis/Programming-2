using BlackjackLibrary;
using System;

/* TODO
 *  Complete
 *      B-2 Methods
 *      B-4
 * 
 *  add some randomness to spliting the
 *  make cards look nicer and align them better
 *  comment code to explain what each peice does
 *  
*/
namespace Blackjack
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            int userChoice = 0;
            while(userChoice != 3)
            {
                Console.Write("1. Play Blackjack\n2. Shuffle and Show Deck\n3. Exit\n");
                switch (ReadInteger("choice", 1, 3))
                {
                    case 1:
                        Console.WriteLine("Not Implemented yet! Press any key to return to the menu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        deck.Shuffle();

                        for (int i = 0; i < 52; i++)
                        {
                            deck._card[i].Draw(Console.CursorLeft + 5, Console.CursorTop);
                        }

                        Console.ReadKey();

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

            Console.WriteLine("Thanks for playing! Press any key to exit...");
            Console.ReadKey();
        }

        #region ReadInteger
        static int ReadInteger(string prompt, int min, int max)
        {
            bool valid = false;
            int readIntInput = 0;
            string errorMessage = $"Input was not between {min} and {max}!";

            // while loop to continue asking the user for a valid input
            while (valid == false)
            {
                Console.Write($"Please enter a value for a {prompt} that is between {min} and {max}: ");

                // if to check if input is a number within min and max
                if (int.TryParse(Console.ReadLine(), out readIntInput) && readIntInput >= min && readIntInput <= max)
                {
                    break;
                }

                // error message for user
                else
                {
                    Console.WriteLine($"{errorMessage}");
                }
            }

            return readIntInput;
        }
        #endregion
    }
}
