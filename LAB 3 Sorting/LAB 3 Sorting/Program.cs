using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LAB_3_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lists made from loaded file, one to sort, one unsorted
            List<string> namesUnsorted = new List<string>(LoadFile().Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
            List<string> sortedList = new List<string>(namesUnsorted);
            sortedList.Sort();

            // getting longest word for formating in the console
            #region Longest Word
            int longestWord = 0;

            foreach (string word in namesUnsorted)
            {
                if (word.Length > longestWord)
                {
                    longestWord = word.Length;
                }
            }
            #endregion

            // options in this array will be displayed as Option #. array entry
            string[] menuOptions = new string[] {
                "Bubble Sort",
                "Merge Sort",
                "Binary Search",
                "Exit"
            };

            int userInput = 0;

            // Keeps the user in the menu until they select the exit option
            while (userInput != 4)
            {
                ReadChoice("Option", menuOptions, out userInput);

                switch (userInput)
                {
                    // Bubble sorting. Shows an unsorted list on the left and a bubble sorted list on the right
                    #region case 1
                    case 1:
                        List<string> bubbleSortedList = new List<string>(namesUnsorted);
                        BubbleSort(bubbleSortedList);

                        Console.WriteLine("\nBubble Sort");
                        Console.WriteLine("----------------------------------------------------------------------------------");

                        for (int i = 0; i < namesUnsorted.Count; i++)
                        {
                            Console.Write(namesUnsorted[i]);
                            Console.SetCursorPosition(longestWord + 5, Console.CursorTop);
                            Console.Write($"{bubbleSortedList[i]}\n");
                        }

                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion

                    // Merge sorting. Shows an unsorted list on the left and a merge sorted list on the right
                    #region case 2
                    case 2:
                        Console.WriteLine("\nMerge Sort");
                        Console.WriteLine("----------------------------------------------------------------------------------");

                        List<string> mergeSorted = new List<string>(namesUnsorted);
                        MergeSort(mergeSorted);

                        for (int i = 0; i < namesUnsorted.Count; i++)
                        {
                           Console.Write(namesUnsorted[i]);
                           Console.SetCursorPosition(longestWord + 5, Console.CursorTop);
                           Console.Write($"{MergeSort(namesUnsorted)[i]}\n");
                        }

                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion

                    // Binary Search. Uses the sorted list to display on the left. The index is shown in the middle. The binary serach is then called to find the index and displays it on the right
                    #region case 3
                    case 3:                        
                        Console.WriteLine("\nBinary Search");
                        Console.WriteLine("----------------------------------------------------------------------------------");                        

                        for (int i = 0; i < sortedList.Count; i++)
                        {
                            string termToSearch = sortedList[i];
                            Console.Write(sortedList[i]);
                            Console.SetCursorPosition(longestWord + 5, Console.CursorTop);
                            Console.Write($"Index: {i}");
                            Console.SetCursorPosition(longestWord + 18, Console.CursorTop);
                            Console.WriteLine($"Found Index: {BinarySearch(sortedList, termToSearch, 0, sortedList.Count())}");
                        }                      
                        
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion

                    #region case 4
                    case 4:                        
                        break;
                    #endregion
                }
            }

            // Clears console and centers exit message
            string exitMsg = "Press any key to exit.";
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - exitMsg.Length / 2, Console.WindowHeight / 2);
            Console.Write(exitMsg);
            Console.ReadKey();

        }


        // Method to open a file, read it into a string, then close the file and return that string
        #region LoadFile Method            
        static string LoadFile()
        {
            string line = "";

            using (var reader = new StreamReader("inputFile.csv"))
            {
                line = reader.ReadLine();
            }

            return line;
        }
        #endregion

        #region BubbleSort Method
        static List<string> BubbleSort(List<string> givenList)
        {
            bool swapped = true;

            int numberOfElements = givenList.Count();

            // Loop to go through and swap elements
            while (swapped == true)
            {
                swapped = false;

                for (int index = 1; index < numberOfElements; index++)
                {
                    if (givenList[index - 1].CompareTo(givenList[index]) == 1)
                    {
                        Swap(givenList, index);
                        swapped = true;
                    }
                }
                numberOfElements = numberOfElements - 1;
            }

            return givenList;
        }
        #endregion

        // Method to swap two strings if the first element is greater than the second.
        #region Swap Method
        static List<string> Swap(List<string> givenList, int index)
        {
            string temp = "";

            temp = givenList[index - 1];
            givenList[index - 1] = givenList[index];
            givenList[index] = temp;

            return givenList;
        }
        #endregion

        #region BinarySearch Method
        static int BinarySearch(List<string> givenList, string searchTerm, int low, int high)
        {
            int mid;

            if (high < low)
            {
                mid = -1;
            }
            else
            {
                mid = (low + high) / 2;
                int compareResult = givenList[mid].CompareTo(searchTerm);

                if (compareResult == 1)
                {
                    mid = BinarySearch(givenList, searchTerm, low, mid - 1);
                }
                else if (compareResult == -1)
                {
                    mid = BinarySearch(givenList, searchTerm, mid + 1, high);
                }
                else if (compareResult != 0)
                {
                    mid = -1;
                }
            }

            return mid;
        }
        #endregion

        // MergeSort Method to split a list recursively, then merge them back sorted.
        #region MergeSort
        static List<string> MergeSort(List<string> givenList)
        {
            if (givenList.Count <= 1)
            {
                return givenList;
            }

            List<string> left = new List<string>();
            List<string> right = new List<string>();

            for (int i = 0; i < givenList.Count; i++)
            {
                if (i < (int)givenList.Count / 2)
                {
                    left.Add(givenList[i]);
                }
                else
                {
                    right.Add(givenList[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }
        #endregion

        // Merges two lists and sorts them.
        #region Merge
        static List<string> Merge(List<string> left, List<string> right)
        {
            List<string> mergedList = new List<string>();

            while (left.Count() != 0 && right.Count() != 0)
            {
                if (left.First().CompareTo(right.First()) == -1 || left.First().CompareTo(right.First()) == 0)
                {
                    mergedList.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    mergedList.Add(right.First());
                    right.Remove(right.First());
                }
            }

            while (right.Count() != 0)
            {
                mergedList.Add(right.First());
                right.Remove(right.First());
            }

            while (left.Count() != 0)
            {
                mergedList.Add(left.First());
                left.Remove(left.First());
            }

            return mergedList;
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

        // Verifies if the given input is valid
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
