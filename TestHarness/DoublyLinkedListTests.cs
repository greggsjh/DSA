using System;
using System.Diagnostics;
using DSA.DoublyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarness
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> _linkedList = new DoublyLinkedList<int>();
        public DoublyLinkedListTests()
        {
            _linkedList.Append(0);
            _linkedList.Append(1);
            _linkedList.Append(2);
            _linkedList.Append(3);
        }

        [TestMethod]
        public void TestAppend()
        {
            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                if (current.Value != i)
                    Assert.Fail();
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            Assert.IsTrue(true);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod]
        public void TestPrepend()
        {
            _linkedList.Prepend(100);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            Assert.AreEqual(_linkedList.Head.Value, 100);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod]
        public void TestGet()
        {
            var current = _linkedList.Head;
            var item = _linkedList.Get(2);

            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            Debug.WriteLine($"item = {item.Value}");
            Debug.WriteLine($"head = {_linkedList.Head.Value}");
            Debug.WriteLine($"tail = {_linkedList.Tail.Value}");

            Assert.AreEqual(item.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

    }

}