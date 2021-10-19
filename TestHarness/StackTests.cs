using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace TestHarness
{
    [TestClass]
    public class StackTests
    {
        public MyStack<int> TestStack { get; set; }
        [TestInitialize]
        public void Init()
        {
            TestStack = new MyStack<int>();
            TestStack.Push(3);
            TestStack.Push(2);
            TestStack.Push(1);
        }

        [TestMethod, TestCategory("Stacks")]
        public void Test_Push()
        {
            TestStack.Push(10);

            Assert.AreEqual(TestStack.Peek(), 10);
        }

        [TestMethod, TestCategory("Stacks")]
        public void Test_Pop()
        {
            TestStack.Push(10);
            Assert.AreEqual(TestStack.Peek(), 10);

            var result = TestStack.Pop();

            Assert.AreEqual(result, 10);
            Assert.AreEqual(TestStack.Peek(), 1);
        }

        [TestMethod, TestCategory("Stacks")]
        public void Test_IsEmpty()
        {
            var isEmpty = TestStack.IsEmpty();
            Assert.IsFalse(isEmpty);

            var result = TestStack.Pop();
            result = TestStack.Pop();
            result = TestStack.Pop();

            isEmpty = TestStack.IsEmpty();
            Assert.IsTrue(isEmpty);

        }

        [TestMethod, TestCategory("Stacks")]
        public void Test_Peek()
        {
            var result = TestStack.Peek();
            Assert.AreEqual(result, 1);

            result = TestStack.Peek();
            Assert.AreEqual(result, 1);
        }
    }
}