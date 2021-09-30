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

            Console.ReadKey();
        }

        #region ReadInteger Method
        static int ReadInteger(string prompt, int min, int max)
        {
            bool valid = false;
            int userInput = 0;

            // while loop to continue asking the user for a valid input
            while(valid == false)
            {
                Console.Write($"Please enter a value for {prompt} that is between {min} and {max}: ");

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
        #endregion

        #region ReadString Method
        static void ReadString(string prompt, ref string value)
        {
            bool valid = false;

            // loops until user input is valid
            while(valid == false)
            {
                Console.Write($"Please enter a {prompt}: ");
                string userInput = Console.ReadLine();

                // checks is user input is empty or only whitespace
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    value = userInput;
                    break;
                }

                // error message for user
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Input was not valid! Please enter a {prompt}!");
                }
            }
        }
        #endregion
    }
}
