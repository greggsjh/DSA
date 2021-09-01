using System;
using Algorithms;
using DSA.SinglyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarness
{
    [TestClass]
    public class RemoveDuplicatesTests
    {
        public RemoveDuplicatesTests()
        {

        }

        [TestMethod]
        public void RemoveDuplicatesTest_One()
        {
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
            linkedList.Append(1);
            linkedList.Append(1);
            linkedList.Append(3);
            linkedList.Append(4);
            linkedList.Append(4);
            linkedList.Append(4);
            linkedList.Append(5);
            linkedList.Append(6);
            linkedList.Append(6);

            LinkedListAlgorithms linkedListAlgorithms = new LinkedListAlgorithms();
            var result = linkedListAlgorithms.RemoveDuplicates(linkedList.Head);

            var current = result;
            var expectedOutput = new int[] { 1, 3, 4, 5, 6 };

            int count = 0;
            while (current.Next != null)
            {
                Console.WriteLine($"item {count}: {current.Value}");
                Assert.AreEqual(current.Value, expectedOutput[count]);
                current = current.Next;
                count++;
            }

            Assert.AreEqual(count + 1, expectedOutput.Length);
        }

    }
}