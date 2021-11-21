using System;
using System.Collections;

namespace Queue
{
    public static class QueueTools
    {
        public static void PushByPos<TValue>(Queue<TValue> queue, TValue value, int pos)
        {
            if (pos < 0) throw new ArgumentOutOfRangeException($"Queue size: {queue.Size}, pos: {pos}");
            if (pos >= queue.Size)
            {
                queue.Push(value);
                return;
            }
   
            var before = pos;
            var after = queue.Size - pos;

            while(before-- > 0) queue.Rotate();
            queue.Push(value);
            while(after-- > 0) queue.Rotate();
    
        }
        
        public static TValue PopByPos<TValue>(Queue<TValue> queue, int pos)
        {
            if (pos < 0 || pos >= queue.Size) throw new ArgumentOutOfRangeException($"Queue size: {queue.Size}, pos: {pos}");

            var before = pos;
            var after = queue.Size - pos;

            while (before-- > 0) queue.Rotate();
            var node = queue.Pop();
            while (--after > 0) queue.Rotate();
    
            return node;
        }
        
        public static void Swap<TValue>(Queue<TValue> queue, int pos1, int pos2)
        {
            var min = pos1 < pos2 ? pos1 : pos2;
            var max = pos1 >= pos2 ? pos1 : pos2;

            if (min < 0 || max >= queue.Size) throw new ArgumentOutOfRangeException();

            var temp = PopByPos(queue, min);
            PushByPos(queue, PopByPos(queue, max - 1), min);
            PushByPos(queue, temp, max);

        }
        
        public static TValue Seek<TValue>(Queue<TValue> queue, int pos)
        {
            if (pos < 0 || pos >= queue.Size) throw new ArgumentOutOfRangeException();
            
            for (int i = 0; i < pos; i++) queue.Rotate();
            var value = queue.Head.Value;
            for (int i = 0; i < queue.Size - pos; i++) queue.Rotate();

            return value;
        }

        public static void Clean<TValue>(Queue<TValue> queue)
        {
	        while (!queue.IsEmpty()) queue.Pop();
        }
    }

    public static class QueueSortTools
    {
        
        public static void SelectionSort<TValue>(Queue<TValue> queue)
        {
            
            for (int i = 0; i < queue.Size; i++)
            {
                var min_val = QueueTools.Seek(queue, i);
                var miv_val_pos = i;

                for (int j = i + 1; j < queue.Size; j++)
                {
                    var val = QueueTools.Seek(queue, j);
                    if (Comparer.Default.Compare(val, min_val ) == -1)
                    {
                        min_val = val;
                        miv_val_pos = j;
                    }
                }

                if (miv_val_pos != i)
                {
                    QueueTools.Swap(queue, i, miv_val_pos);
                }
            }
        }

   //      public static void MergeSort<TValue>(Queue<TValue> queue)
   //      {
   //          int blockSizeIterator;
   //          Queue<TValue> outQueue = new();
   //
   //          for (blockSizeIterator = 1; blockSizeIterator < queue.Size; blockSizeIterator *= 2)
			// {
			// 	int blockIterator;
			// 	for (blockIterator = 0; blockIterator < queue.Size - blockSizeIterator; blockIterator += 2 * blockSizeIterator)
			// 	{
			// 		var leftBlockIterator = 0;
			// 		var rightBlockIterator = 0;
			// 		var leftBorder = blockIterator;
			// 		var midBorder = blockIterator + blockSizeIterator;
			// 		var rightBorder = blockIterator + 2 * blockSizeIterator;
			// 		
			// 		rightBorder = rightBorder < queue.Size ? rightBorder : queue.Size;
			// 		Queue<TValue> sortedBlock = new ();
			// 		
			// 		while (leftBorder + leftBlockIterator < midBorder && midBorder + rightBlockIterator < rightBorder)
			// 		{
			// 			if (Comparer.Default.Compare(QueueTools.Seek(queue, leftBorder + leftBlockIterator), QueueTools.Seek(queue, midBorder + rightBlockIterator)) == -1)
			// 			{
			// 				QueueTools.PushByPos(sortedBlock,
			// 					QueueTools.Seek(queue, leftBorder + leftBlockIterator),
			// 					leftBlockIterator + rightBlockIterator);
			// 				
			// 				leftBlockIterator += 1;
			// 			}
			// 			else
			// 			{
			// 				QueueTools.PushByPos(sortedBlock,
			// 					QueueTools.Seek(queue, midBorder + rightBlockIterator),
			// 					leftBlockIterator + rightBlockIterator);
			// 				
			// 				rightBlockIterator += 1;
			// 			}
			// 		}
			// 		
			// 		while (leftBorder + leftBlockIterator < midBorder)
			// 		{
			// 			QueueTools.PushByPos(sortedBlock,
			// 				QueueTools.Seek(queue, leftBorder + leftBlockIterator),
			// 				leftBlockIterator + rightBlockIterator);
			// 			
			// 			leftBlockIterator += 1;
			// 		}
			// 		
			// 		while (midBorder + rightBlockIterator < rightBorder)
			// 		{
			// 			QueueTools.PushByPos(sortedBlock,
			// 				QueueTools.Seek(queue, midBorder + rightBlockIterator),
			// 				leftBlockIterator + rightBlockIterator);
			// 			
			// 			rightBlockIterator += 1;
			// 		}
			// 		
   //
			// 		for (int mergeIterator = 0; mergeIterator < leftBlockIterator + rightBlockIterator; mergeIterator++)
			// 		{ 
			// 			QueueTools.PushByPos(outQueue,
			// 				QueueTools.Seek(sortedBlock, mergeIterator),
			// 				leftBorder + mergeIterator);
			// 		}
			// 		
			// 		Console.WriteLine(sortedBlock);
			// 	}
			// }
   //          
   //          QueueTools.Clean(queue);
   //          while(!outQueue.IsEmpty()) queue.Push(outQueue.Pop());
   //      }
    }
}