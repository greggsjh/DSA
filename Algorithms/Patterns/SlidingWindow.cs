using System;

namespace Algorithms.Patterns
{
    public static class SlidingWindow
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
            int max = 0; //largest sum
            int currentSum = 0; //the sum of the current subarray

            int leftIndex = 0; //represents start of window
            int rightIndex = 0; //represents end of window

            //Time Complexity is O(n), where n is the size of arr
            //Space Complexity is O(1), since we don't need create to anything to store 
            //the items in the array. We only create two items to store the running sum, left index
            //, right index, and the max sum; all requiring constant space
            while (rightIndex < arr.Length)
            {
                int currentSubArrLength = rightIndex - leftIndex + 1;
                if (currentSubArrLength > k)
                {
                    currentSum = currentSum - arr[leftIndex];
                    leftIndex++;
                }

                currentSum = currentSum + arr[rightIndex];
                max = Math.Max(max, currentSum);
                rightIndex++; //expand the window   
            }

            return max;
        }
    }
}