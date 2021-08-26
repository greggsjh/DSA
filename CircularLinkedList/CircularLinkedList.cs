using System;

namespace DSA.CircularLinkedList
{
    public class CircularLinkedList<T>
    {
        private Node<T> _head;
        public Node<T> Head
        {
            get { return _head; }
            set { _head = value; }
        }

        private Node<T> _tail;
        public Node<T> Tail
        {
            get { return _tail; }
            set { _tail = value; }
        }

        public CircularLinkedList()
        {

        }

        public class Node<TValue> where TValue : T
        {
            private TValue _value;
            public TValue Value
            {
                get { return _value; }
                set { _value = value; }
            }

            private Node<TValue> _next;
            public Node<TValue> Next
            {
                get { return _next; }
                set { _next = value; }
            }

            private Node<TValue> _prev;
            public Node<TValue> Prev
            {
                get { return _prev; }
                set { _prev = value; }
            }

            public Node(TValue value)
            {
                _value = value;
                _prev = null;
                _next = null;
            }

        }

    }
}
