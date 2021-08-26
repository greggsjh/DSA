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
            if (Head == null)
            {
                return;
            }

            if (Head.Value.Equals(value))
            {
                Head.Next.Prev = null;
                Head = Head.Next;
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    var temp = current.Prev;

                    if (current == Tail)
                    {
                        Tail = temp;
                        temp.Next = current.Next;
                        return;
                    }

                    temp.Next = current.Next;
                    temp.Next.Prev = temp;

                    return;
                }
                current = current.Next;
            }
        }

        public Node<T> InsertBefore(Node<T> node, T value)
        {
            if (Head == null)
            {
                return null;
            }

            var newNode = new Node<T>(value);

            if (Head.Value.Equals(node.Value))
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
                return Head;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(node.Value))
                {
                    current.Prev.Next = newNode;
                    newNode.Next = current;
                    newNode.Prev = current.Prev;
                    current.Prev = newNode;
                    return Head;
                }
                current = current.Next;
            }

            return Head;
        }

        public Node<T> InsertAfter(Node<T> node, T value)
        {
            if (Head == null)
            {
                return null;
            }

            var newNode = new Node<T>(value);

            if (Tail.Value.Equals(node.Value))
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
                return Head;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(node.Value))
                {
                    current.Next.Prev = newNode;
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    current.Next = newNode;
                    return Head;
                }

                current = current.Next;
            }

            return Head;
        }

        public class Node<TValue> where TValue : T
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
