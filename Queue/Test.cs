using System;

namespace Queue
{
    public static class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            Random r = new (Environment.TickCount);
            for (int i = 0; i < 10; i++) queue.Push(r.Next(-99, 100));
            
            Console.WriteLine(queue);
            QueueSortTools.SelectionSort(queue);
            Console.WriteLine(queue);
        }
    }
}