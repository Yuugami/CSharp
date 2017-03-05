using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Solution
{
    class Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            // Variables
            int number;

            // A. Print out Array
            PrintArray(intArray);
            // B. Prompt the user to enter an integer to find
            Console.Write("\nEnter an integer to find.\n");
            string numberSt = Console.ReadLine();

            /* C. It calls the method SearchIntArray to search the user 
             * entered integer in the unsorted array. 
             * 
             * If found, it outputs the index of the number the user entered 
             * and the number of comparisons it used to find the
             * index.
             */
            if (Int32.TryParse(numberSt, out number))
            {
                int length = intArray.Length;
                int index = SearchIntArray(intArray, number, ref length);
                if (index < 0)
                {
                    Console.Write($"{number} could not be found in the array.\n");
                }
                else
                {
                    Console.Write($"{number} is found at Index {index}\n");
                }
                Console.Write($"{length} comparisons were made during the process.\n");
            }
            /* D. Call the method BubbleSort to sort the array. 
             * After sorting, it outputs the number of swapping it performed to sort the array
             */
            int numOfSwaps = BubbleSort(intArray);
            Console.Write($"It took {numOfSwaps} swaps to sort the array via Bubble Sort.\n\n");
            
            /* E. Output the sorted array elements to the console window.*/
            PrintArray(intArray);

            /* F. It prompts the user to enter an integer again. 
             * For this lab, your application does not have to handle the
             * situation when the user enters non-integers. 
             */
            Console.Write("\nSelect another integer!\n");
            numberSt = Console.ReadLine();
            /* G. It calls the method BinarySearch to search the user entered
             * integer in the sorted array. 
             * 
             * If found, it outputs the index of at which the user entered 
             * value was found and number of comparisons it used to find the index.
             * 
             * If not found, it outputs the number of comparisons it used to 
             * conclude that the user entered value is not in the array.
             */
            if (Int32.TryParse(numberSt, out number))
            {
                int length = intArray.Length;
                int index = BinarySearch(intArray, number, ref length);
                if (index < 0)
                {
                    Console.Write($"{number} could not be found in the array.\n");
                }
                else
                {
                    Console.Write($"{number} is found at Index {index}\n");
                }
                Console.Write($"{length} comparisons were made during the process.\n");
            }
            Console.ReadLine();
        }

        static int SearchIntArray(int[] haystack, int niddle, ref int numOfComparison)
        {
            int niddleIndex = -1;

            //Here you search the niddle in the haystack.
            numOfComparison = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                numOfComparison++;
                if (haystack[i] == niddle)
                {
                    niddleIndex = i;
                    break;
                }
            }

            return niddleIndex;
        }


        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;

            //Here you implement the bubble sort to sort the integer array arr.
            bool swap = false;
            do
            {
                swap = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < (arr.Length - 1) && arr[i] > arr[i + 1])
                    {
                        //Console.Write($"{arr[i]} is bigger than {arr[i + 1]}\n");
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swap = true;
                        numOfSwaps++;
                    }
                }
            } while (swap);
            
            return numOfSwaps;
        }


        static int BinarySearch(int[] haystack, int niddle, ref int numOfComparison)
        {
            int niddleIndex = -1;

            //Here you implement the binary search to find the niddle in the haystack.
            int RightSide = haystack.Length - 1;
            int LeftSide = 0;
            numOfComparison = 0;
            do
            {
                double MiddleElement = (LeftSide + RightSide) / 2;
                MiddleElement = Math.Floor(MiddleElement);
                if (haystack[(int)MiddleElement] < niddle)
                {
                    LeftSide = (int)MiddleElement + 1;
                    //Console.Write($"{niddle} is bigger than {haystack[(int)MiddleElement]}\n");
                }
                else if (haystack[(int)MiddleElement] > niddle)
                {
                    RightSide = (int)MiddleElement - 1;
                    //Console.Write($"{niddle} is less than {haystack[(int)MiddleElement]}\n");
                }
                else
                {
                    niddleIndex = (int)MiddleElement;
                }
                numOfComparison++;
            } while (LeftSide < RightSide && niddleIndex == -1);

            return niddleIndex;
        }

        //call this method to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
