using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Heap<T> where T : IComparable<T>
    {
        T[] heap;
        public int Size { get; set; }
        public bool Empty
        {
            get
            {
                return Size == 0;
            }
        }
        public T Top
        {
            get
            {
                if (Size == 0) throw new IndexOutOfRangeException();
                return heap[0];
            }
        }
        public T Pop()
        {
            if (Size == 0) throw new IndexOutOfRangeException();
            Size--;
            Swap(0, Size);
            int father = 0;
            while (father * 2 + 1 < Size)
            {
                int i = father;
                if (heap[father].CompareTo(heap[father * 2 + 1]) > 0)
                {
                    i = father * 2 + 1;
                }
                if (father * 2 + 2 < Size)
                {
                    if (heap[i].CompareTo(heap[father * 2 + 2]) > 0)
                    {
                        i = father * 2 + 2;
                    }
                }
                if (i != father)
                {
                    Swap(i, father);
                    father = i;
                }
                else
                {
                    break;
                }
            }
            return heap[Size];
        }
        public void Push(T t)
        {
            if (Size == heap.Length) throw new IndexOutOfRangeException();
            int i = Size;
            while (i != 0 && heap[(i - 1) / 2].CompareTo(t) > 0)
            {
                heap[i] = heap[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            heap[i] = t;
            Size++;
        }
        void Swap(int x, int y)
        {
            T tmp = heap[x];
            heap[x] = heap[y];
            heap[y] = tmp;
        }

        public Heap(int MaxCount)
        {
            heap = new T[MaxCount];
            Size = 0;
        }
    }
}
