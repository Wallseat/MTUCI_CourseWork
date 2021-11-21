using System;

namespace Queue
{
    public static class QueueTools
    {
        public static void Swap<TValue>(Queue<TValue> queue, int pos1, int pos2)
        {
            var min = pos1 < pos2 ? pos1 : pos2;
            var max = pos1 >= pos2 ? pos1 : pos2;

            if (min < 0 || max >= queue.Size) throw new ArgumentOutOfRangeException();

            for (int i = 0; i < min; i++) queue.Rotate();
            var min_val = queue.Pop();
            for (int i = 0; i < max - min - 1; i++) queue.Rotate();
            var max_val = queue.Pop();
            
            queue.Push(min_val);
            for (int i = 0; i < queue.Size - min - 1; i++) queue.Rotate();
            queue.Push(max_val);
            for (int i = 0; i < queue.Size - min - 1; i++) queue.Rotate();

        }
        
        public static TValue Seek<TValue>(Queue<TValue> queue, int pos)
        {
            if (pos < 0 || pos >= queue.Size) throw new ArgumentOutOfRangeException();
            
            for (int i = 0; i < pos; i++) queue.Rotate();
            var value = queue.Head.Value;
            for (int i = 0; i < pos; i++) queue.Rotate();

            return value;
        }
    }

    public static class QueueSortTools
    {
        public static void SelectionSort(Queue<IComparable> queue)
        {
            for (int i = 0; i < queue.Size; i++)
            {
                var min_val = QueueTools.Seek(queue, i);
                var miv_val_pos = i;

                for (int j = i; j < queue.Size; j++)
                {
                    var val = QueueTools.Seek(queue, j);
                    if (val.CompareTo(min_val) == -1)
                    {
                        min_val = val;
                        miv_val_pos = j;
                    }
                }

                if (miv_val_pos != i)
                {
                    QueueTools.Swap(queue, i, miv_val_pos + 1);
                }
                Console.WriteLine(queue);
            }
        }
    }
}