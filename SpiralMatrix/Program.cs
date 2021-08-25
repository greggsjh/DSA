using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralMatrix
{
    public class Program
    {
        public static void Main()
        {
            int[][] matrix = new int[3][] { new int[4] { 1, 2, 3, 4 }, new int[4] { 5, 6, 7, 8 }, new int[4] { 9, 10, 11, 12 } };

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (int item in SpiralOrder2(matrix))
            {
                sb.Append(item);
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            Console.WriteLine(sb.ToString());
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            int x = 0, y = 0;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int area = m * n;
            Direction currentDirection = Direction.Right;

            int rightPivot = n - 1;
            int downPivot = m - 1;
            int leftPivot = 0;
            int upPivot = 0;

            List<int> result = new List<int>();

            int count = 0;
            result.Add(matrix[y][x]);
            while (count < area)
            {
                switch (currentDirection)
                {
                    case Direction.Right:
                        if (x == rightPivot)
                        {
                            currentDirection = Direction.Down;
                            rightPivot--;
                        }
                        else
                        {
                            x++;
                        }
                        break;
                    case Direction.Down:
                        if (y == downPivot)
                        {
                            currentDirection = Direction.Left;
                            downPivot--;
                        }
                        else
                        {
                            y++;
                        }
                        break;
                    case Direction.Left:
                        if (x == leftPivot)
                        {
                            currentDirection = Direction.Up;
                            leftPivot++;
                        }
                        else
                        {
                            x--;
                        }
                        break;
                    case Direction.Up:
                        if (y == upPivot)
                        {
                            currentDirection = Direction.Right;
                            upPivot++;
                        }
                        else
                        {
                            y--;
                        }
                        break;
                }
                count++;
                result.Add(matrix[y][x]);
            }

            return result;
        }


        /*
        Write a function that takes in an n x m two-dimensional array (that can be
        square-shaped when n == m) and returns a one-dimensional array of all the
        array's elements in spiral order.

        Spiral order starts at the top left corner of the two-dimensional array, goes
        to the right, and proceeds in a spiral pattern all the way until every element
        has been visited.

        Sample Input:
        matrix = [ [1, 2, 3, 4], [12, 13, 14, 5], [11, 16, 15, 6], [10,  9,  8, 7]]
        Sample Output:
        [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]

        matrix: 
            sc       ec
         sr  1  2  3  4 
            12 13 14  5
            11 16 15  6
         er 10  9  8  7

         [sr, sc] -> [sr,ec]
         sr++
         [sr, ec] -> [er, ec]
         ec++
         [er, ec] -> [er, sc]
         er--
         [er, sc] -> [sr, sc]
        */
        public static IList<int> SpiralOrder2(int[][] matrix)
        {
            List<int> result = new List<int>();
            int startingRow = 0;
            int startingColumn = 0;
            int endingRow = matrix.Length - 1;
            int endingColumn = matrix[0].Length - 1;

            while (startingColumn <= endingColumn && startingRow <= endingRow)
            {
                //traverse top row
                for (int i = startingColumn; i <= endingColumn; i++)
                {
                    result.Add(matrix[startingRow][i]);
                }
                startingRow++;

                //traverse last column
                for (int i = startingRow; i <= endingRow; i++)
                {
                    result.Add(matrix[i][endingColumn]);
                }
                endingColumn--;

                //traverse last row
                for (int i = endingColumn; i >= startingColumn; i--)
                {
                    if (endingRow > startingRow) break;
                    result.Add(matrix[endingRow][i]);
                }
                endingRow--;

                //traverse first column
                for (int i = endingRow; i >= startingRow; i--)
                {
                    if (startingColumn > endingColumn) break;
                    result.Add(matrix[i][startingColumn]);
                }
                startingColumn++;

            }

            return result;
        }
        enum Direction
        {
            Left,
            Down,
            Right,
            Up
        }
    }
}
