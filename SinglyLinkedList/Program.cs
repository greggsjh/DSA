using System;

namespace DSA.SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
            linkedList.Append(0);
            linkedList.Append(1);
            linkedList.Append(2);

            var current = linkedList.Head;
            for (int i = 0; current != null; current = current.Next, i++)
            {
                Console.WriteLine($"item {i} = {current.Value}");
            }
        }
    }
}