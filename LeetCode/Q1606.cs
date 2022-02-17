using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1606
{
    public class Solution
    {
        public IList<int> BusiestServers(int k, int[] arrival, int[] load)
        {
            Heap<int> availableServers = new Heap<int>(k);
            Heap<Server> busyServers = new Heap<Server>(k);
            int[] requestNum = new int[k];
            for (int i = 0; i < k; i++)
            {
                availableServers.Push(i);
            }
            for (int i = 0; i < arrival.Length; i++)
            {
                while (busyServers.Size != 0)
                {
                    if (busyServers.Top.freeTime <= arrival[i])
                    {
                        if (i % k > busyServers.Top.server)
                        {
                            availableServers.Push(i / k * k + busyServers.Pop().server + k);
                        }
                        else
                        {
                            availableServers.Push(i / k * k + busyServers.Pop().server);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (availableServers.Size != 0)
                {
                    int server = availableServers.Pop();
                    busyServers.Push(new Server(server % k, arrival[i] + load[i]));
                    requestNum[server % k]++;
                }
            }
            IList<int> ans = new List<int>();
            int busiest = 0;
            for (int i = 0; i < k; i++)
            {
                if (busiest < requestNum[i])
                {
                    busiest = requestNum[i];
                    ans = new List<int> { i };
                }
                else if (busiest == requestNum[i])
                {
                    ans.Add(i);
                }
            }
            return ans;
        }
    }

    public struct Server : IComparable<Server>
    {
        public int server;
        public int freeTime;
        public Server(int server, int freeTime)
        {
            this.server = server;
            this.freeTime = freeTime;
        }

        public int CompareTo(Server other)
        {
            return freeTime - other.freeTime;
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
                if(heap[father].CompareTo(heap[father*2+1]) > 0)
                {
                    i = father*2 + 1;
                }
                if(father * 2 + 2 < Size)
                {
                    if (heap[i].CompareTo(heap[father * 2 + 2]) > 0)
                    {
                        i = father * 2 + 2;
                    }
                }
                if(i != father)
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
