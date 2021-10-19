using System;
using System.Diagnostics;
using DSA.CircularLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarness
{
    [TestClass]
    public class CircularLinkedListTests
    {
        private CircularLinkedList<int> _linkedList = new CircularLinkedList<int>();
        public CircularLinkedListTests()
        {
            _linkedList.Append(1);
            _linkedList.Append(2);
            _linkedList.Append(3);
            _linkedList.Append(4);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestPrepend()
        {
            var head = _linkedList.Prepend(100);

            var current = _linkedList.Head;
            for (int i = 0; current != _linkedList.Tail; i++)
            {
                Debug.WriteLine($"item {i}: {current.Value}");
                current = current.Next;
            }


            Assert.AreEqual(head.Value, 100);
            Assert.AreEqual(_linkedList.Tail.Value, 4);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestAppend()
        {
            var head = _linkedList.Append(100);

            var current = _linkedList.Head;
            for (int i = 0; current != _linkedList.Tail; i++)
            {
                Debug.WriteLine($"item {i}: {current.Value}");
                current = current.Next;
            }

            Assert.AreEqual(head.Value, 1);
            Assert.AreEqual(_linkedList.Tail.Value, 100);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestGet()
        {
            //Test get middle
            var item = _linkedList.GetNode(3);
            Assert.AreEqual(item.Value, 3);

            //Test get tail
            item = _linkedList.GetNode(_linkedList.Tail.Value);
            Assert.AreEqual(item.Value, _linkedList.Tail.Value);

            //Test get head
            item = _linkedList.GetNode(_linkedList.Head.Value);
            Assert.AreEqual(item.Value, _linkedList.Head.Value);

            //Test get tail after append
            _linkedList.Append(100);
            item = _linkedList.GetNode(_linkedList.Tail.Value);
            Assert.AreEqual(item.Value, _linkedList.Tail.Value);

            //Test get head after prepend
            _linkedList.Prepend(101);
            item = _linkedList.GetNode(_linkedList.Head.Value);
            Assert.AreEqual(item.Value, _linkedList.Head.Value);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestDelete()
        {
            var head = _linkedList.Delete(3);
            Assert.IsNull(_linkedList.GetNode(3));
            Assert.AreEqual(_linkedList.Tail.Prev.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 1);

            head = _linkedList.Delete(_linkedList.Head.Value);
            Assert.IsNull(_linkedList.GetNode(1));
            Assert.AreEqual(_linkedList.Head.Value, 2);

            head = _linkedList.Delete(_linkedList.Tail.Value);
            Assert.IsNull(_linkedList.GetNode(4));
            Assert.AreEqual(_linkedList.Tail.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 2);

            head = _linkedList.Delete(3);
            Assert.IsNull(_linkedList.GetNode(3));
            Assert.AreEqual(_linkedList.Tail.Value, 2);
            Assert.AreEqual(_linkedList.Head.Value, 2);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestInsertBefore()
        {
            var targetNode = _linkedList.GetNode(3);

            var head = _linkedList.InsertBefore(targetNode, 100);
            Assert.IsNotNull(_linkedList.GetNode(100));
            Assert.AreEqual(targetNode.Prev.Value, 100);
            Assert.AreEqual(_linkedList.Tail.Value, 4);
            Assert.AreEqual(_linkedList.Head.Value, 1);

            head = _linkedList.InsertBefore(head, 101);
            Assert.IsNotNull(_linkedList.GetNode(101));
            Assert.AreEqual(_linkedList.Tail.Value, 4);
            Assert.AreEqual(_linkedList.Head.Value, 101);

            head = _linkedList.InsertBefore(_linkedList.Tail, 102);
            Assert.IsNotNull(_linkedList.GetNode(102));
            Assert.AreEqual(_linkedList.Tail.Prev.Value, 102);
            Assert.AreEqual(_linkedList.Tail.Value, 4);
            Assert.AreEqual(_linkedList.Head.Value, 101);
        }

        [TestMethod, TestCategory("CircularLinkedLists")]
        public void TestInsertAfter()
        {
            var targetNode = _linkedList.GetNode(3);

            var head = _linkedList.InsertAfter(targetNode, 100);
            Assert.IsNotNull(_linkedList.GetNode(100));
            Assert.AreEqual(targetNode.Next.Value, 100);
            Assert.AreEqual(_linkedList.Tail.Value, 4);
            Assert.AreEqual(_linkedList.Head.Value, 1);

            head = _linkedList.InsertAfter(head, 101);
            Assert.IsNotNull(_linkedList.GetNode(101));
            Assert.AreEqual(_linkedList.Tail.Value, 4);
            Assert.AreEqual(_linkedList.Head.Value, 1);
            Assert.AreEqual(head.Next.Value, 101);

            head = _linkedList.InsertAfter(_linkedList.Tail, 102);
            Assert.IsNotNull(_linkedList.GetNode(102));
            Assert.AreEqual(_linkedList.Head.Prev.Value, 102);
            Assert.AreEqual(_linkedList.Tail.Value, 102);
            Assert.AreEqual(_linkedList.Head.Value, 1);
        }
    }
}