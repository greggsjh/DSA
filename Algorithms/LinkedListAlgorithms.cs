using System;
using DSA.SinglyLinkedList;

namespace Algorithms
{
    public class LinkedListAlgorithms
    {
        /*
        Sample input: 1->1->3->4->4->4->5->6->6
        Sample output: 1->3->4->5->6
        */
        /// <summary>
        /// Removes the duplicate values from a singly linked list given the head of the list
        /// </summary>
        /// <param name="head"></param>
        /// <returns>the head node of the singly linked list</returns>
        public Node<int> RemoveDuplicates(Node<int> head)
        {
            var result = head;
            var current = head;
            while (current.Next != null)
            {
                if (current.Value == current.Next.Value)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            return result;
        }
    }
}
