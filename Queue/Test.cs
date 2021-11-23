using System;

namespace Queue
{
    public static class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            Random r = new (Environment.TickCount);
            for (int i = 0; i < 1000; i++) queue.Push(r.Next(-99, 100));
            
            QueueSortTools.MergeSort(queue);
            Console.WriteLine(queue);
            Console.WriteLine();
            
            QueueTools.Clean(queue);
            
            for (int i = 0; i < 1000; i++) queue.Push(r.Next(-99, 100));
            QueueSortTools.SelectionSort(queue);
            Console.WriteLine(queue);
        }
    }
}