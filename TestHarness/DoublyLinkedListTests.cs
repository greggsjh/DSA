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

        [TestMethod, TestCategory("DoublyLinkedLists")]
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

        [TestMethod, TestCategory("DoublyLinkedLists")]
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

        [TestMethod, TestCategory("DoublyLinkedLists")]
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

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestDelete()
        {
            var current = _linkedList.Head;
            _linkedList.Delete(2);

            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var item = _linkedList.Get(1).Next;

            Debug.WriteLine($"item = {item.Value}");
            Debug.WriteLine($"head = {_linkedList.Head.Value}");
            Debug.WriteLine($"tail = {_linkedList.Tail.Value}");

            Assert.AreEqual(item.Value, 3);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestDeleteHead()
        {
            var current = _linkedList.Head;
            _linkedList.Delete(_linkedList.Head.Value);

            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var item = _linkedList.Head;

            Debug.WriteLine($"item = {item.Value}");
            Debug.WriteLine($"head = {_linkedList.Head.Value}");
            Debug.WriteLine($"tail = {_linkedList.Tail.Value}");

            Assert.AreEqual(item.Value, 1);
            Assert.AreEqual(_linkedList.Head.Value, 1);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestDeleteTail()
        {
            var current = _linkedList.Head;
            _linkedList.Delete(_linkedList.Tail.Value);

            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var item = _linkedList.Tail;

            Debug.WriteLine($"item = {item.Value}");
            Debug.WriteLine($"head = {_linkedList.Head.Value}");
            Debug.WriteLine($"tail = {_linkedList.Tail.Value}");

            Assert.AreEqual(item.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 2);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestInsertBefore()
        {
            var item = _linkedList.Get(2);
            _linkedList.InsertBefore(item, 100);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var newItem = _linkedList.Get(100);
            Assert.AreEqual(newItem.Next.Value, item.Value);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestInsertBeforeHead()
        {
            var item = _linkedList.Head;
            _linkedList.InsertBefore(item, 100);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var newItem = _linkedList.Get(100);
            Assert.AreEqual(newItem.Next.Value, item.Value);
            Assert.AreEqual(_linkedList.Head.Value, 100);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestInsertAfter()
        {
            var item = _linkedList.Get(1);
            _linkedList.InsertAfter(item, 101);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var newItem = _linkedList.Get(101);
            Assert.AreEqual(newItem.Value, item.Next.Value);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 3);
        }

        [TestMethod, TestCategory("DoublyLinkedLists")]
        public void TestInsertAfterTail()
        {
            var item = _linkedList.Get(_linkedList.Tail.Value);
            _linkedList.InsertAfter(item, 100);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var newItem = _linkedList.Get(100);
            Assert.AreEqual(newItem.Value, item.Next.Value);
            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.AreEqual(_linkedList.Tail.Value, 100);
        }

    }

}