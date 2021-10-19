using System;

namespace Stack
{
    public class MyStack<T>
    {
        public StackNode<T> Top { get; set; }
        public void Push(T item)
        {
            StackNode<T> newItem = new StackNode<T>(item);
            if (IsEmpty())
            {
                Top = newItem;
                return;
            }

            newItem.Next = Top;
            Top = newItem;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            var result = Top.Data;
            Top = Top.Next;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            return Top.Data;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }
    }

    public class StackNode<T>
    {
        public StackNode(T item) => Data = item;
        public T Data { get; set; }
        public StackNode<T> Next { get; set; } = null;
    }
}
