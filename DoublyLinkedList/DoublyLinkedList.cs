using System;

namespace DSA.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public Node<T> Get(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        public Node<T> Prepend(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
                return Head;
            }

            newNode.Prev = null;
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;

            return Head;
        }

        public Node<T> Append(T value)
        {
            var newNode = new Node<T>(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
                return Head;
            }

            newNode.Next = null;
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;

            return Head;
        }

        public void Delete(T value)
        {

        }

        public Node<T> InsertBefore(Node<T> node, T value)
        {
            throw new NotImplementedException();
        }

        public Node<T> InsertAfter(Node<T> node, T Value)
        {
            throw new NotImplementedException();
        }

        public class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Prev { get; set; }
            public Node<TValue> Next { get; set; }

            public Node(TValue val)
            {
                Value = val;
                Prev = null;
                Next = null;
            }
        }
    }
}
