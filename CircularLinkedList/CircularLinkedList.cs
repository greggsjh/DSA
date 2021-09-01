namespace DSA.CircularLinkedList
{
    /// <summary>
    /// A circular doubly linked list that holds values of type T
    /// </summary>
    /// <typeparam name="T">The type of values contained in the list</typeparam>
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
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// Inserts a value of type T at the end of the linked list in O(1) time
        /// </summary>
        /// <param name="val">The value to be inserted</param>
        /// <returns>The head of the Circular Linked List</returns>
        public Node<T> Append(T val)
        {
            if (_head == null)
            {
                _head = _tail = new Node<T>(val);
                return _head;
            }
            /*
                1. Create new node
                2. Set new node's previous pointer to the tail
                3. Set new node's next pointer to the head
                4. Set the tail's next pointer to the new new node
                5. Set the head's previous pointer to the new node
                6. Set the tail to the new node
            */
            var newNode = new Node<T>(val);
            newNode.Prev = _tail;
            newNode.Next = _head;
            _tail.Next = newNode;
            _head.Prev = newNode;
            _tail = newNode;

            return _head;
        }

        /// <summary>
        /// Inserts a value of type T at the beginning of the linked list in O(1) time
        /// </summary>        
        /// <param name="val">The value to be inserted</param>
        /// <returns>The head of the Circular Linked List</returns>
        public Node<T> Prepend(T val)
        {
            if (_head == null)
            {
                _head = _tail = new Node<T>(val);
                return _head;
            }

            /*
                1. Create the new node
                2. Set the new node's next pointer to the head
                3. Set the new node's previous pointer to the tail
                4. Set the head's previous pointer to the new node
                5. Set the tail's next pointer to the new node
                6. Set the head to the new node 
            */
            var newNode = new Node<T>(val);
            _head.Prev = newNode;
            _tail.Next = newNode;
            newNode.Next = _head;
            newNode.Prev = _tail;
            _head = newNode;

            return _head;
        }

        /// <summary>
        /// Gets the first occurrence of the value of type T in O(n) time
        /// </summary>
        /// <param name="val">The value to search for</param>
        /// <returns>the node that holds the first occurrence of the value</returns>
        public Node<T> GetNode(T val)
        {
            if (_head == null)
                return null;

            var current = _head;
            bool isFirstTime = true;
            while (current != _head || isFirstTime)
            {
                if (current.Value.Equals(val))
                {
                    return current;
                }

                current = current.Next;
                isFirstTime = false;
            }

            return null;
        }

        /// <summary>
        /// Deletes the first occurrence of the value of type T in O(n) time
        /// </summary>
        /// <param name="val">The value to be deleted</param>
        /// <returns>The head of the Circular Linked List</returns>
        public Node<T> Delete(T val)
        {
            if (GetNode(val) == null)
            {
                return _head;
            }

            if (_head == _tail)
            {
                _head = _tail = null;
                return _head;
            }

            var current = _head;
            var prev = _head;
            bool isFirstTime = true;
            while (current != _head || isFirstTime)
            {
                if (current.Value.Equals(val))
                {
                    if (current == _head)
                    {
                        prev.Prev.Next = current.Next;
                        current.Next.Prev = prev.Prev;
                        _head = current.Next;
                        break;
                    }

                    prev.Next = current.Next;
                    current.Next.Prev = prev;

                    if (current == _tail) _tail = current.Prev;

                    break;
                }

                prev = current;
                current = current.Next;
                isFirstTime = false;
            }

            return _head;
        }

        /// <summary>
        /// Inserts new value of type T before the specified node in O(n) time
        /// </summary>
        /// <param name="node">The node to insert the new value before</param>
        /// <param name="val">The value to be inserted</param>
        /// <returns>The head of the Circular Linked List</returns>
        public Node<T> InsertBefore(Node<T> node, T val)
        {
            if (_head == null)
            {
                _head = node;
                return _head;
            }

            var newNode = new Node<T>(val);
            if (node == _head)
            {
                newNode.Next = _head;
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _head.Prev = newNode;
                _head = newNode;
                return _head;
            }

            var current = _head;
            bool isFirstTime = true;
            while (current != _tail.Next || isFirstTime == true)
            {
                if (current == node)
                {
                    newNode.Next = current;
                    newNode.Prev = current.Prev;
                    current.Prev.Next = newNode;
                    current.Prev = newNode;
                    return _head;
                }

                current = current.Next;
                isFirstTime = false;
            }

            return _head;
        }

        /// <summary>
        /// Inserts new value of type T after the specified node in O(n) time
        /// </summary>
        /// <param name="node">The node to insert the new value after</param>
        /// <param name="val">The value to be inserted</param>
        /// <returns>The head of the Circular Linked List</returns>
        public Node<T> InsertAfter(Node<T> node, T val)
        {
            if (_head == null)
            {
                _head = node;
                return _head;
            }

            var newNode = new Node<T>(val);
            if (_tail == node)
            {
                newNode.Next = _tail.Next;
                newNode.Prev = _tail;
                _tail.Next.Prev = newNode;
                _tail.Next = newNode;
                _tail = newNode;
                return _head;
            }

            var current = _head;
            bool isFirstTime = true;
            while (current != _tail.Next || isFirstTime)
            {
                if (current == node)
                {
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    current.Next.Prev = newNode;
                    current.Next = newNode;
                    return _head;
                }
                current = current.Next;
                isFirstTime = false;
            }

            return _head;
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
