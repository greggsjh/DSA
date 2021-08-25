using System.Collections.Generic;

namespace DSA.SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        private Node<T> _head;
        public Node<T> Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public SinglyLinkedList()
        {
            _head = null;
        }

        /// <summary>
        /// Get the value from the linked list in O(n) time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Get(T value)
        {
            var current = _head;
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

        /// <summary>
        /// Inserts the <paramref name="value"/> at the end of the linked list in O(1) time
        /// </summary>
        /// <param name="value"></param>
        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        /// <summary>
        /// Inserts the <paramref name="value"> at the beginning of the linked list in O(1) time
        /// </summary>
        /// <param name="value"></param>
        public void Prepend(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = _head;
            _head = newNode;

        }

        /// <summary>
        /// Removes the first occurrence of <paramref name="value"> from the linked list in O(1) time
        /// </summary>
        /// <param name="value"></param>
        public void Delete(T value)
        {
            if (_head == null)
                return;

            var next = _head;
            var prev = _head;
            while (next.Next != null)
            {
                if (next.Value.Equals(value))
                {
                    prev.Next = next.Next;
                    next = null;
                    return;
                }
                prev = next;
                next = next.Next;
            }
        }

        public void InsertBefore(Node<T> node, T value)
        {
            var next = _head;
            var prev = _head;
            while (next.Next != null)
            {
                if (next == node)
                {
                    var temp = new Node<T>(value);
                    prev.Next = temp;
                    temp.Next = next;
                }

                prev = next;
                next = next.Next;
            }
        }

        public void InsertAfter(Node<T> node, T value)
        {
            var current = _head;

            while (current.Next != null)
            {
                if (current == node)
                {
                    var temp = current.Next.Next;
                    current.Next = new Node<T>(value);
                    current.Next.Next = temp;
                }
                current = current.Next;
            }
        }

        public class Node<TValue>
        {
            public Node<TValue> Next { get; set; }
            public TValue Value { get; set; }

            public Node(TValue value)
            {
                Value = value;
                Next = null;
            }
        }
    }
}