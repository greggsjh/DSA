using System;
using System.Diagnostics;
using Algorithms.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarness
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod, TestCategory("SlidingWindowPattern")]
        public void Test_FindMaximumSubArray_SlidingWindow()
        {
            int[] arr = new int[] { 2, 1, 5, 1, 3, 2 };
            int result = SlidingWindow.FindMaximumSubArray(3, arr);
            int expectedResult = 9;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("SlidingWindowPattern")]
        public void Test_FindMaximumSubArray2_SlidingWindow()
        {
            int[] arr = new int[] { 2, 3, 4, 1, 5 };
            int result = SlidingWindow.FindMaximumSubArray(2, arr);
            int expectedResult = 7;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("SlidingWindowPattern")]
        public void Test_FindMaximumSubArray_BruteForce()
        {
            int[] arr = new int[] { 2, 1, 5, 1, 3, 2 };
            int result = BruteForce.FindMaximumSubArray(3, arr);
            int expectedResult = 9;

            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod, TestCategory("SlidingWindowPattern")]
        public void Test_FindMaximumSubArray2_BruteForce()
        {
            int[] arr = new int[] { 2, 3, 4, 1, 5 };
            int result = BruteForce.FindMaximumSubArray(2, arr);
            int expectedResult = 7;

            Assert.AreEqual(expectedResult, result);
        }

    }
}