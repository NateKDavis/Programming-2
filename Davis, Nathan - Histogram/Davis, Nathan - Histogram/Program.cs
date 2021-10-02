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
            #region Variables
            int userInput = 0;

            // options in this array will be displayed as Option #. array entry
            string[] menuOptions = new string[] {
                "Show Histogram",
                "Search for Word",
                "Save Histogram",
                "Load Histogram",
                "Remove Word",
                "Exit"
            };

            // delimeters for spliting given text
            char[] delimeters = new char[]
            {
                ',',
                '.',
                '!',
                ':',
                ';',
                ' ',
                '\n',
                '\t',
                '\r'
            };
            #endregion

            // gets speech and splits it into an array, removes empty strings, then converts the array to a list
            List<string> wordList = GetSpeech().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();

            // case-insensitive dictionary
            Dictionary<string, int> wordDic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Adds each unique word in the list to the dictionary and counts how many times each word is used
            foreach (string word in wordList)
            {
                if (wordDic.ContainsKey(word))
                {
                    wordDic[word]++;
                }

                else
                {
                    wordDic.Add(word, 1);
                }
            }

            Console.WriteLine("Welcome to Lab 1: Histogram!");

            // Keeps the user in the menu
            while(userInput != 6)
            {
                ReadChoice("Option", menuOptions, out userInput);

                switch (userInput)
                {
                    #region case 1
                    case 1:
                        Console.WriteLine();

                        // Prints each word, number of times that word shows up, and a bar in the dictionary formatted with color and positioning.
                        foreach(KeyValuePair<string, int> word in wordDic)
                        {   
                            // alternates the colors of the lines
                            if(Console.CursorTop % 2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }

                            // adjusts the postions and prints the words
                            Console.SetCursorPosition((Console.CursorLeft + 15) - word.Key.Length, Console.CursorTop);
                            Console.Write(word.Key);
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.Write($"{word.Value}");

                            // set the background color to make a bar. alternates the color each line
                            if (Console.CursorTop % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }

                            // sets potions for the bar to print from
                            Console.SetCursorPosition(25, Console.CursorTop);

                            // prints space to match the value
                            for (int i = 0; i < word.Value; i++)
                            {
                                Console.Write(" ");
                            }

                            // resets for the next line
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        break;
                    #endregion

                    case 2:
                        string wordToSearch = "";
                        ReadString("What word do you want to find? ", ref wordToSearch);
                        Console.WriteLine();

                        if (wordDic.ContainsKey(wordToSearch))
                        {
                            Console.SetCursorPosition((Console.CursorLeft + 15) - wordDic.ContainsKey(wordToSearch).ToString().Length, Console.CursorTop);
                            Console.Write(wordToSearch);
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.Write(wordDic[wordToSearch]);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(25, Console.CursorTop);

                            for (int i = 0; i < wordDic[wordToSearch]; i++)
                            {
                                Console.Write(" ");
                            }

                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        break;

                    case 3:
                        Console.WriteLine("\n\t\tNot Implemented! Returning you to Menu...");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("\n\t\tNot Implemented! Returning you to Menu...");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("\n\t\tNot Implemented! Returning you to Menu...");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Invalid selection!");
                        break;
                }
                Console.ReadKey();
            }

            // Clears console and centers exit message
            string exitMsg = "Press any key to exit.";
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - exitMsg.Length / 2, Console.WindowHeight / 2);
            Console.Write(exitMsg);
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
                        Console.WriteLine($"Input was not between {min} and {max}!");
                    }
                }

                // error message for user
                else
                {
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
                Console.Write(prompt);
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
                    Console.WriteLine($"Input was not valid! \n");
                }
            }
        }
        #endregion

        #region ReadChoice Method
        static void ReadChoice(string prompt, string[] options, out int selection)
        {
            int idx = 1;

            Console.WriteLine();

            // print each option in the given index
            foreach (string item in options)
            {
                Console.WriteLine($"Option {idx++}. {item}");
            }

            Console.WriteLine();

            // asks for and checks user's input. then saves it
            selection = ReadInteger(prompt, 1, options.Length);
        }
        #endregion

        #region GetSpeech Method
        static string GetSpeech()
        {
            string text = "I say to you today, my friends, so even though we face the difficulties of today and tomorrow, I still have a dream. It is a dream deeply rooted in the American dream. " +
                "I have a dream that one day this nation will rise up and live out the true meaning of its creed: We hold these truths to be self-evident: that all men are created equal. " +
                "I have a dream that one day on the red hills of Georgia the sons of former slaves and the sons of former slave owners will be able to sit down together at the table of brotherhood. " +
                "I have a dream that one day even the state of Mississippi, a state sweltering with the heat of injustice, sweltering with the heat of oppression, will be transformed into an oasis of freedom and justice. " +
                "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character. " +
                "I have a dream today. I have a dream that one day, down in Alabama, with its vicious racists, with its governor having his lips dripping with the words of interposition and nullification; one day right there in Alabama, little black boys and black girls will be able to join hands with little white boys and white girls as sisters and brothers. " +
                "I have a dream today. I have a dream that one day every valley shall be exalted, every hill and mountain shall be made low, the rough places will be made plain, and the crooked places will be made straight, and the glory of the Lord shall be revealed, and all flesh shall see it together. " +
                "This is our hope. This is the faith that I go back to the South with. With this faith we will be able to hew out of the mountain of despair a stone of hope. With this faith we will be able to transform the jangling discords of our nation into a beautiful symphony of brotherhood. " +
                "With this faith we will be able to work together, to pray together, to struggle together, to go to jail together, to stand up for freedom together, knowing that we will be free one day. " +
                "This will be the day when all of God's children will be able to sing with a new meaning, My country, 'tis of thee, sweet land of liberty, of thee I sing. Land where my fathers died, land of the pilgrim's pride, from every mountainside, let freedom ring. " +
                "And if America is to be a great nation this must become true. So let freedom ring from the prodigious hilltops of New Hampshire. Let freedom ring from the mighty mountains of New York. Let freedom ring from the heightening Alleghenies of Pennsylvania! " +
                "Let freedom ring from the snowcapped Rockies of Colorado! Let freedom ring from the curvaceous slopes of California! But not only that; let freedom ring from Stone Mountain of Georgia! " +
                "Let freedom ring from Lookout Mountain of Tennessee! Let freedom ring from every hill and molehill of Mississippi. From every mountainside, let freedom ring. " +
                "And when this happens, when we allow freedom to ring, when we let it ring from every village and every hamlet, from every state and every city, we will be able to speed up that day when all of God's children, black men and white men, Jews and Gentiles, Protestants and Catholics, will be able to join hands and sing in the words of the old Negro spiritual, Free at last! free at last! thank God Almighty, we are free at last!";

            return text;
        }
        #endregion
    }
}
