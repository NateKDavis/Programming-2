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
            int userInput = 0;

            string[] menuOptions = new string[] {
                "Show Histogram",
                "Search for Word",
                "Save Histogram",
                "Load Histogram",
                "Remove Word",
                "Exit"
            };

            Console.WriteLine("Welcome to Lab 1: Histogram!");

            while(userInput != 6)
            {
                ReadChoice("Option", menuOptions, out userInput);

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("\n\t\tNot Implemented!");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("\n\t\tNot Implemented!");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("\n\t\tNot Implemented!");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("\n\t\tNot Implemented!");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("\n\t\tNot Implemented!");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Invalid selection!");
                        break;
                }
            }

            Console.Write("\nPress any key to exit.");
            Console.ReadKey();
        }

        #region ReadInteger Method
        static int ReadInteger(string prompt, int min, int max)
        {
            bool valid = false;
            int readIntInput = 0;

            // while loop to continue asking the user for a valid input
            while(valid == false)
            {
                Console.Write($"Please enter a value for a {prompt} that is between {min} and {max}: ");

                // if to check if input is a number
                if( int.TryParse(Console.ReadLine(), out readIntInput) )
                {
                    // if to check if number is with in min and max
                    if(readIntInput >= min && readIntInput <= max)
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

            return readIntInput;
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
                string readStringInput = Console.ReadLine();

                // checks is user input is empty or only whitespace
                if (!string.IsNullOrWhiteSpace(readStringInput))
                {
                    value = readStringInput;
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

        #region ReadChoice Method
        static void ReadChoice(string prompt, string[] options, out int selection)
        {
            int idx = 1;

            Console.WriteLine();

            foreach (string item in options)
            {
                Console.WriteLine($"Option {idx++}. {item}");
            }

            Console.WriteLine();

            selection = ReadInteger(prompt, 1, options.Length);
        }
        #endregion
    }
}
