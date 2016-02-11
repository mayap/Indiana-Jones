using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int capacity = 16;

            // maximum capacity of bag
            int capacity = int.Parse(Console.ReadLine());

            int index = 0;

            // Reads text from file
            using (TextReader reader = File.OpenText("input.txt"))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                {
                    index++;
                }
            }

            int[] valueArray = new int[index];
            int[] weightArray = new int[index];

            // Reads lines from file and splits each line
            using (TextReader reader = File.OpenText("input.txt"))
            {
                string text = string.Empty;
                int n = 0;
                while ((text = reader.ReadLine()) != null)
                {
                    string[] bits = text.Split(' ');

                    String itemName = bits[0];
                    valueArray[n] = int.Parse(bits[1]);
                    weightArray[n] = int.Parse(bits[2]);
                    n++;
                }

            }
            Console.WriteLine(knapSack(capacity, weightArray, valueArray, index));
        }

        // Returns max number from two numbers
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that can be put in a knapsack of given capacity
        static int knapSack(int capacity, int[] weight, int[] value, int n)
        {
            int[,] K = new int[n + 1, capacity + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (weight[i - 1] <= w)
                    {
                        K[i, w] = max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }
            return K[n, capacity];
        }
    }
}
