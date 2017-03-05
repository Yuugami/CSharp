using System;
using System.Diagnostics;

public class lab2
{
    public static void Main(string[] args)
    {
        /* Variables */
        int max = 0, min = 0, numOfNums = 0, sum = 0;
        double avg = 0.0;
        bool flag = true;

        // Prompt user for integers
        Console.Write("Please enter integers, one at a time (to stop, just press enter.)\n");
        // While the game is running...
        while (flag)
        {
            string input = Console.ReadLine();
            // If the user inputs nothing and no integers were entered, the game ends.
            if (input == "" && numOfNums == 0)
            {
                Console.Write("You did not enter any integers.\n");
                flag = false;
            }
            // Otherwise if the input is empty and there are integers entered, 
            // and show results.
            else if (input == "")
            {
                flag = false;
                avg = Convert.ToDouble(sum) / Convert.ToDouble(numOfNums);
                Console.Write($"Maximum Value: {max}\n");
                Console.Write($"Minimum Value: {min}\n");
                Console.Write($"Total number of integers: {numOfNums} \n");
                Console.Write($"Sum of all integers: {sum} \n");
                Console.Write($"Avg of all integers: {avg} \n");

                Console.Write("Play Again?\n");
                char ans = ((char)Console.Read());
                Debug.WriteLine(ans);
                ans = char.ToLower(ans);
                if (ans == 'y')
                {
                    flag = true;
                    max = min = numOfNums = sum = 0;
                    Console.Write("Please enter integers, one at a time (to stop, just press enter.)\n");
                    input = Console.ReadLine();
                }
            }
            else
            {
                int number = Convert.ToInt32(input);
      
                if (numOfNums == 0)
                {
                    max = min = sum = number;
                    numOfNums++;
                }
                else
                {
                    if (number > max)
                        max = number;

                    if (number < min)
                        min = number;

                    numOfNums++;

                    sum += number;
                }
            }
        }
        Console.ReadKey();
    }
}