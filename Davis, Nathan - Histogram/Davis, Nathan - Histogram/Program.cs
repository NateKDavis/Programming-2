using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davis__Nathan___Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Speech Histogram!");
            int input = Program.ReadInteger("year", 10, 200);

            Console.ReadKey();
        }

        public static int ReadInteger(string prompt, int min, int max)
        {
            // Initalizing vaiables. valid to continue while loop. userInput to store what is entered for returning. 
            bool valid = false;
            int userInput = 0;

            // while loop to continue asking the user for a valid input
            while(valid == false)
            {
                Console.Write($"Please enter a number between {min} and {max} for {prompt}: ");

                // if to check if input is a number
                if( int.TryParse(Console.ReadLine(), out userInput) )
                {
                    // if to check if number is with in min and max
                    if(userInput >= min && userInput <= max)
                    {
                        break;
                    }

                    // error message for user
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Input was not between {min} and {max}!");
                    }
                }

                // error message for user
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input was not a number!");
                }

            }

            return userInput;
        }
    }
}
