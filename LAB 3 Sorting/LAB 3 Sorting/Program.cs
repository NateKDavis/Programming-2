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

            // Keeps the user in the menu
            while (userInput != 4)
            {
                ReadChoice("Option", menuOptions, out userInput);

                switch (userInput)
                {
                    #region case 1
                    case 1:
                        List<string> bubbleSortedList = new List<string>(BubbleSort(namesUnsorted));

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

                    #region case 2
                    case 2:
                        List<string> mergeSortedList = new List<string>(MergeSort(namesUnsorted));

                        Console.WriteLine("\nMerge Sort");
                        Console.WriteLine("----------------------------------------------------------------------------------");

                        foreach (string item in mergeSortedList)
                        {
                            Console.WriteLine(item);
                        }
                        //for (int i = 0; i < namesUnsorted.Count; i++)
                        //{
                         //   Console.Write(namesUnsorted[i]);
                        //    Console.SetCursorPosition(longestWord + 5, Console.CursorTop);
                         //   Console.Write($"{mergeSortedList[i]}\n");
                        //}

                        Console.ReadKey();
                        Console.Clear();

                        break;
                    #endregion

                    #region case 3
                    case 3:
                        

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
            List<string> BubbleSort(List<string> givenList)
            {
                List<string> listToSort = new List<string>(givenList);
                bool swapped = true;

                int numberOfElements = listToSort.Count();

                // Loop to go through and swap elements
                while (swapped == true)
                {
                    swapped = false;

                    for (int index = 1; index < numberOfElements; index++)
                    {
                        if (listToSort[index - 1].CompareTo(listToSort[index]) == 1)
                        {
                            Swap(listToSort, index);
                            swapped = true;
                        }
                    }
                    numberOfElements = numberOfElements - 1;
                }

                return listToSort;
            }
            #endregion

            // Method to swap to strings if the first element is greater than the second.
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
            int BinarySearch(List<string> givenList, string searchTerm, int low, int high)
            {
                int mid;

                if (givenList.Count < low)
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
            List<string> MergeSort(List<string> givenList)
            {
                List<string> listToSort = new List<string>(givenList);
                List<string> left = new List<string>();
                List<string> right = new List<string>();

                if (listToSort.Count <= 1)
                {

                }
                else
                {
                    for (int i = 0; i < listToSort.Count; i++)
                    {
                        if (i < listToSort.Count / 2)
                        {
                            left.Add(listToSort[i]);
                        }
                        else
                        {
                            right.Add(listToSort[i]);
                        }
                    }

                    MergeSort(left);
                    MergeSort(right);
                }

                return Merge(left, right);
            }
            #endregion

            // Merges two lists and sorts them.
            #region Merge
            List<string> Merge(List<string> left, List<string> right)
            {
                List<string> mergedList = new List<string>();

                while(left.Count() != 0 && right.Count() != 0)
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

                if(right.Count == 0)
                {
                    while(left.Count() != 0)
                    {
                        mergedList.Add(left.First());
                        left.Remove(left.First());
                    }
                }
                else
                {
                    while (right.Count() != 0)
                    {
                        mergedList.Add(right.First());
                        right.Remove(right.First());
                    }
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
}
