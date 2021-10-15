using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Davis__Nathan___Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TODOS:
               make methods for
                generating the bar based on word count
                sending error or success and reseting to menu
                reloading the sentence and word lists
            
               Adding sorting to the histogram
            */

            #region Variables
            int userInput = 0;
            int largestWordLength = 0;

            // options in this array will be displayed as Option #. array entry
            string[] menuOptions = new string[] {
                "Show Histogram",
                "Search for Word",
                "Save Histogram",
                "Load Histogram",
                "Remove Word",
                "Exit"
            };

            // delimeters for spliting given text into words
            char[] delimetersWordSplit = new char[]
            {
                ',',
                '.',
                '!',
                ':',
                ';',
                ' ',
                '"',
                '?',
                ']',
                '[',
                '\n',
                '\t',
                '\r'
            };

            // delimeters for spliting into sentences
            char[] delimetersSentenceSplit = new char[]
            {
                '.',
                '!',
                '?'
            };

            // case-insensitive dictionary
            Dictionary<string, int> wordDic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            #endregion

            #region load histogram
            // gets speech and splits it into an array, removes empty strings, then converts the array to a list
            List<string> wordList = GetSpeechFromFile().Split(delimetersWordSplit, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> sentences = GetSpeechFromFile().Split(delimetersSentenceSplit, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

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

            // gets the largest word for formatting purposes
            foreach (KeyValuePair<string, int> word in wordDic)
            {
                if (word.Key.Length > largestWordLength)
                {
                    largestWordLength = word.Key.Length;
                }
            }
            #endregion

            // Keeps the user in the menu
            while (userInput != 6)
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
                            Console.SetCursorPosition((Console.CursorLeft + largestWordLength + 1) - word.Key.Length, Console.CursorTop);
                            Console.Write(word.Key);
                            Console.SetCursorPosition((Console.CursorLeft + 3), Console.CursorTop);
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

                            HistogramFormator(word.Value);

                            // prints space to match the value
                            for (int i = 0; i < word.Value; i++)
                            {
                                Console.Write(" ");
                            }

                            // resets for the next line
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion

                    #region case 2
                    case 2:
                        string wordToSearch = "";
                        
                        ReadString("\nWhat word do you want to find? ", ref wordToSearch);

                        string caseTwoErrorMsg = $"The word {wordToSearch} was not found! Press any key to return to the menu..";

                        // checks if the word is in the dictionary, if it is not shows an error. 
                        if (wordDic.ContainsKey(wordToSearch))
                        {
                            Console.Write($"\n{wordToSearch}");
                            Console.SetCursorPosition((Console.CursorLeft + 3), Console.CursorTop);
                            Console.Write(wordDic[wordToSearch]);
                            Console.BackgroundColor = ConsoleColor.White;

                            HistogramFormator(wordDic[wordToSearch]);

                            for (int i = 0; i < wordDic[wordToSearch]; i++)
                            {
                                Console.Write(" ");
                            }

                            Console.ResetColor();
                            Console.WriteLine("\n");

                            // checks sentences for the search word
                            foreach (string sentence in sentences)
                            {
                                string[] sentenceWords = sentence.Split(delimetersWordSplit, StringSplitOptions.RemoveEmptyEntries);

                                foreach (string word in sentenceWords)
                                {
                                    if (word.Equals(wordToSearch))
                                    {
                                        Console.WriteLine(sentence.TrimStart());
                                        break;
                                    }
                                }
                            }

                            Console.WriteLine();
                        }

                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(Console.WindowWidth / 2 - caseTwoErrorMsg.Length / 2, Console.WindowHeight / 2);
                            Console.WriteLine(caseTwoErrorMsg);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    #endregion

                    #region case 3
                    case 3:
                        string fileNameToSave = "";
                        ReadString("\nPlease enter the file name to save: ", ref fileNameToSave);

                        // checks and corrects the file extension Make a method given time
                        if (Path.GetExtension(fileNameToSave) != ".json")
                        {
                            fileNameToSave = Path.ChangeExtension(fileNameToSave, ".json");
                        }

                        // trys to save the file or throws an error
                        try
                        {
                            File.WriteAllText($@"D:\FullSail\PG2\PG2_Code\Davis, Nathan - Histogram\Saved Histograms\{fileNameToSave}", JsonConvert.SerializeObject(wordDic));
                            Console.WriteLine($"\nFile saved as {fileNameToSave}. Press any key to return to the menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch
                        {
                            Console.WriteLine("\nFile could not save!");
                        }

                        break;
                    #endregion

                    #region case 4
                    case 4:
                        string fileNameToLoad = "";

                        Console.WriteLine();
                        ReadString("Please enter the file name to load: ", ref fileNameToLoad);

                        // checks and corrects file extension. Make a method given time
                        if (Path.GetExtension(fileNameToLoad) != ".json")
                        {
                            fileNameToLoad = Path.ChangeExtension(fileNameToLoad, ".json");
                        }

                        try
                        {
                            wordDic.Clear();
                            wordDic = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText($@"D:\FullSail\PG2\PG2_Code\Davis, Nathan - Histogram\Saved Histograms\{fileNameToLoad}"));
                            Console.WriteLine("\nFile loaded. Press any key to return to the menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                        catch
                        {
                            Console.WriteLine("file was not found!");
                        }

                        break;
                    #endregion

                    #region case 5
                    case 5:
                        string wordToRemove = "";
                        ReadString("\nPlease enter a word to remove: ", ref wordToRemove);

                        try
                        {
                            if (wordDic.Remove(wordToRemove))
                            {
                                Console.WriteLine($"\n{wordToRemove} was removed. Press any key to return to the menu..");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        catch
                        {
                            Console.WriteLine($"{wordToRemove} was not in the dictionary! Press any key to return to the menu..");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        
                        break;
                    #endregion

                    case 6:
                        break;
                }
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
            string errorMessage = $"Input was not between {min} and {max}!";

            // while loop to continue asking the user for a valid input
            while (valid == false)
            {
                Console.Write($"Please enter a value for a {prompt} that is between {min} and {max}: ");

                // if to check if input is a number within min and max
                if ( int.TryParse(Console.ReadLine(), out readIntInput) && readIntInput >= min && readIntInput <= max)
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

        #region GetSpeechFromFile Method
        static string GetSpeechFromFile()
        {
            string speech = "";

            using (var reader = new StreamReader("speech.csv"))
            {
                string line = "";

                while((line = reader.ReadLine()) != null)
                {
                    speech = speech + line;
                } 
            }

            return speech;
        }
        #endregion

        #region HistogramFormator Method
        static void HistogramFormator(int givenInt)
        {
            // sets potions for the bar to print from
            if (givenInt < 10)
            {
                Console.SetCursorPosition((Console.CursorLeft + 4), Console.CursorTop);
            }

            else if (givenInt < 100)
            {
                Console.SetCursorPosition((Console.CursorLeft + 3), Console.CursorTop);
            }

            else if (givenInt < 1000)
            {
                Console.SetCursorPosition((Console.CursorLeft + 2), Console.CursorTop);
            }

            else if (givenInt < 10000)
            {
                Console.SetCursorPosition((Console.CursorLeft + 1), Console.CursorTop);
            }
        }
        #endregion
    }
}
