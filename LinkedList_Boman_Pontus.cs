using LaborationInterfaces;
using System;

namespace Boman_Pontus
{
    public class Laboration_2_LinkedList<TypeName> : ILaboration_2_List<TypeName>
    {
        /// <summary>
        /// Describes how a node in the list is constructed.
        /// A node contains:
        /// * Data (of any type) to be stored and handled in the list type
        /// * A reference to the next node in the list.
        /// </summary>
        internal class Node
        {
            internal TypeName Data { get; set; }
            internal Node Next { get; set; }
        }

        private Node first;
        private int Counter;

        public TypeName this[uint i]
        {
            get => Get(i);
            set {; }
        }

        /// <summary>
        /// The constructor creates a dummy node, that acts as sentinel
        /// for the following nodes in the list.
        /// </summary>
        public Laboration_2_LinkedList()
        {
            first = new Node();
        }

        public void AddFirst(TypeName data)
        {
            Node node = new() { Data = data };
            node.Next = first.Next;
            first.Next = node;
            Counter++;
        }

        public void Iterate(Action<TypeName> action)
        {
            Node node = first;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }

        public void AddLast(TypeName data)
        {
            Node node = new Node();
            node.Data = data;

            if (first == null)
            {
                first = node;
                first.Next = null;
            }
            else
            {
                Node current = first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
            Counter++;
        }

        public int Count()
        {
            return this.Counter;
        }

        public int IndexOf(TypeName target)
        {
            Node runner = this.first.Next;
            for (int i = 0; i < Counter; i++)
            {
                if (runner.Data.Equals(target))
                    return i;
                runner = runner.Next;
            }
            return -1;
        }

        public void Insert(uint index, TypeName data)
        {
            Node node = new Node();
            node.Data = data;
            node.Next = null;

            if (index < 0)
                throw new ArgumentOutOfRangeException($"Index: {index}");

            Node current = this.first;
            Node previous = null;
            int i = -1;
            while (i < index)
            {
                previous = current;
                current = current.Next;
                if (current == null)
                    break;
                i++;
            }

            node.Next = current;
            previous.Next = node;

            Counter++;
        }
        public void RemoveAt(uint index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException($"Index {index}");

            Node cur = this.first.Next;
            if (index == 0)
            {
                first.Next = first.Next.Next;
            }
            else if (index >= 1)
            {
                for (int i = 0; i < index - 1; i++)
                    cur = cur.Next;
                cur.Next = cur.Next.Next;
            }
            Counter--;
        }

        public TypeName Get(uint index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException($"Index {index}");
            if (index >= this.Counter)
                index = index = Convert.ToUInt32(Counter) - 1;

            Node cur = this.first.Next;
            for (int i = 0; i < index; i++)
                cur = cur.Next;

            return cur.Data;
        }
    }
}
