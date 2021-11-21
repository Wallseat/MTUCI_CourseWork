using System;

namespace Queue
{
    public static class Program
    {
        public static void Main()
        {
            var queue = new Queue<IComparable>(5, 6, 9, 2, 7, 10, 11, 4);
            
            Console.WriteLine(queue);
            QueueTools.Swap(queue, 3, 5);
            Console.WriteLine(queue);
        }
    }
}