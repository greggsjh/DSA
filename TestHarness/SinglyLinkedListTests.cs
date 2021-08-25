using System.Diagnostics;
using DSA.SinglyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarness
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _linkedList = new SinglyLinkedList<int>();
        public SinglyLinkedListTests()
        {
            _linkedList.Append(0);
            _linkedList.Append(1);
            _linkedList.Append(2);
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

            Assert.AreEqual(_linkedList.Head.Value, 0);
            Assert.IsTrue(true);
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
        }

        [TestMethod]
        public void TestGet()
        {
            var current = _linkedList.Get(2);

            Debug.WriteLine($"item = {current.Value}");

            Assert.AreEqual(current.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 0);
        }

        [TestMethod]
        public void TestDelete()
        {
            Debug.WriteLine($"before delete: {_linkedList.Head}");

            _linkedList.Delete(100);

            Debug.WriteLine($"after delete: {_linkedList.Head}");

            Assert.AreEqual(_linkedList.Head.Value, 0);
        }

        [TestMethod]
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
        }

        [TestMethod]
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
        }

        [TestMethod]
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
        }

        [TestMethod]
        public void TestInsertAfterTail()
        {
            var item = _linkedList.Get(2);
            _linkedList.InsertAfter(item, 100);

            var current = _linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Debug.WriteLine($"item {i} = {current.Value}");
            }

            var newItem = _linkedList.Get(100);
            Assert.AreEqual(newItem.Value, item.Next.Value);
        }
    }
}
