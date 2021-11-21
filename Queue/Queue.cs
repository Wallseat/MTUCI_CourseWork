using System;
using System.Diagnostics.CodeAnalysis;

namespace Queue
{
    public class Node<TValue>
    {
        public TValue Value { get; }
        
        [MaybeNull]
        public Node<TValue> Next { get; set; }

        public Node(TValue value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Node<Value: {Value}>";
        }
    }

    public class Queue<TValue>
    {
        [MaybeNull]
        public Node<TValue> Head { get; private set; }
        
        [MaybeNull]
        public Node<TValue> Tail { get; private set;  }
        public int Size { get; private set; }
        
        public Queue(params TValue[] values)
        {
            Size = 0;
            foreach (var value in values) Push(value);
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }
        
        public void Push(TValue value)
        {
            var node = new Node<TValue>(value);

            if (IsEmpty())
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Size++;
        }

        public TValue Pop()
        {
            if (IsEmpty()) throw new IndexOutOfRangeException("Can't pop from empty queue!");
            
            var node = Head;
            Head = node.Next;
            Size--;

            return node.Value;
        }

        public void Rotate()
        {
            Push(Pop());
        }

        public override string ToString()
        {
            var str = "";
            var node = Head;
           
            while (node != null)
            {
                str += node;
                node = node.Next;
                if (node != null) str += ", ";

            }

            return "Queue[" + str + "]";
        }
    }
}