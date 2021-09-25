using System;

namespace Algorithms.Patterns
{
    public static class BruteForce
    {
        /*
            Given an array of positive numbers and a positive number ‘k,’ 
            find the maximum sum of any contiguous subarray of size ‘k’.

            Example 1
                Input: [2, 1, 5, 1, 3, 2], k=3 
                Output: 9
                Explanation: Subarray with maximum sum is [5, 1, 3].

            Example 2
                Input: [2, 3, 4, 1, 5], k=2 
                Output: 7
                Explanation: Subarray with maximum sum is [3, 4].
        */
        public static int FindMaximumSubArray(int k, int[] arr)
        {
            int max = 0;

            //Time Complexity is O(n * k), where n is the size of arr
            //Space Complexity is O(1), since we don't need create to anything to store 
            //the items in the array. We only create two items to store the running sum and 
            //the max sum; both require constant space.
            for (int i = 0; i < arr.Length - k; i++)
            {
                int currentSum = 0;
                for (int j = i; j < i + k; j++)
                {
                    currentSum += arr[j];
                }
                max = Math.Max(max, currentSum);
            }
            return max;
        }
    }
}