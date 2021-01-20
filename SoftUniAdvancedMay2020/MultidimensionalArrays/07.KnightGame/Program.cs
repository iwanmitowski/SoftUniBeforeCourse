using System;

namespace _07.KnightGame
{
    class Program
    {
        // to do 
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacked = 0;
                int rowKnight = 0;
                int colKnight = 0;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            int currentAttacked = AtackedKnightsCount(matrix, i, j);
                            if (currentAttacked > maxAttacked)
                            {
                                maxAttacked = currentAttacked;
                                rowKnight = i;
                                colKnight = j;
                                
                            }
                        }
                    }
                }
                
                Console.WriteLine(maxAttacked);

                //break
            }




        }

        private static int AtackedKnightsCount(char[,] matrix, int i, int j)
        {
            int count = 0;
            int length = matrix.GetLength(0);
            //   0K0K0
            //   K000K
            //   00K00
            //   K000K
            //   0K0K0

            if (i - 2 >= 0 && j - 1 >= 0 && matrix[i - 2, j - 1] == 'K')
            {
                count++;
            }
            if (i - 2 > 0 && j + 1 < length && matrix[i - 2, j + 1] == 'K')
            {
                count++;
            }
            if (i - 1 >= 0 && j - 2 >= 0 && matrix[i - 1, j - 2] == 'K')
            {
                count++;
            }
            if (i - 1 > 0 && j + 2 < length && matrix[i - 1, j + 2] == 'K')
            {
                count++;
            }

            if (i + 1 < length && j - 2 >= 0 && matrix[i + 1, j - 2] == 'K')
            {
                count++;
            }
            if (i + 1 < length && j + 2 < length && matrix[i + 1, j + 2] == 'K')
            {
                count++;
            }
            if (i + 2 < length && j - 1 >= 0 && matrix[i + 2, j - 1] == 'K')
            {
                count++;
            }
            if (i + 2 < length && j + 1 < length && matrix[i + 2, j + 1] == 'K')
            {
                count++;
            }

            return count;
        }
    }
}
