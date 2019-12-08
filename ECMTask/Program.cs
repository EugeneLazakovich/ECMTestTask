using System;
using System.Collections.Generic;
using System.Linq;

namespace ECMTask
{
    class Program
    {
        static void Main(string[] args)
        {
            object[,] matrix = { { 83, 255, -99, 711, 'w', 199},
                                 { 670, 'Q', 134, 210, 164, 178},
                                 { 135, 123, 330, 241, 177, 213},
                                 { 'q', 169, 143, 154, 194, 126},
                                 { 956, 459, 444, 122, 555, 453},
                                 { 333, 677, 888, 832, 245, 228} };

            if (CheckNumber(Math.Sqrt(matrix.Length)))
            {
                Dictionary<int, object> tempDict = new Dictionary<int, object>();

                for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                    {
                        tempDict.Add((i * (int)Math.Sqrt(matrix.Length)) + j, matrix[i, j]);
                    }
                }

                int increment = 0;
                tempDict = tempDict.OrderBy(pair => Convert.ToInt32(pair.Value)).
                                    ToDictionary(pair => increment++, pair => pair.Value);
                
                int countDictMin = 0;
                for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                    {
                        if (i == j)
                        {
                            matrix[i, j] = tempDict[countDictMin++];
                        }
                        else
                        {
                            matrix[i, j] = tempDict[--increment];
                        }
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The matrix is not N*N form!");
            }
        }
        static Boolean CheckNumber(double doubNum)
        {
            if ((doubNum - (int)doubNum) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
