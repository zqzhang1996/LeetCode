using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q0313
{
    public class Solution
    {
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1) return 1;
            int[] nsun = new int[n];
            Heap<NthSuperUglyNumberHelper> heap = new Heap<NthSuperUglyNumberHelper>(primes.Length);
            for (int i = 0; i < primes.Length; i++)
            {
                heap.Push(new NthSuperUglyNumberHelper(0, primes[i], primes[i]));
            }
            nsun[0] = 1;
            for (int i = 1; i < n - 1; i++)
            {
                int min = heap.Top.NextNum;
                nsun[i] = min;
                while (heap.Top.NextNum == min)
                {
                    var tmp = heap.Pop();
                    tmp.PrevNumId++;
                    tmp.NextNum = tmp.PrimeNum * nsun[tmp.PrevNumId];
                    heap.Push(tmp);
                }
            }
            return heap.Top.NextNum;
        }
    }

    struct NthSuperUglyNumberHelper : IComparable<NthSuperUglyNumberHelper>
    {
        public int PrevNumId { get; set; }
        public int NextNum { get; set; }
        public int PrimeNum { get; set; }

        public NthSuperUglyNumberHelper(int prevNumId, int nextNum, int primeNum)
        {
            PrevNumId = prevNumId;
            NextNum = nextNum;
            PrimeNum = primeNum;
        }

        public int CompareTo(NthSuperUglyNumberHelper other)
        {
            return NextNum - other.NextNum;
        }
    }

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
