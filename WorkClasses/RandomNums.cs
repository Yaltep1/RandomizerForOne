using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
//клас у якому відбувається рандомізація, у клієнтському застосуванні ,за моїм завданням викликається з інтерфейсу в окремому потоці
namespace Randomizer2._0
{class RandomNums{
    private int min;
        public Stack<string> tb;
    private int[] arr;
    public RandomNums(int n1, int n2)
    {
        min = n1 - 1;
        arr = new int[n2 - n1 + 1];
        for (int i = 0, n = n1; i < arr.Length; i++, n++) { arr[i] = n; }
        tb = new Stack<string>();
    }
    public Stack<string> doRandom()
    {

            int l = arr.Length;
            int elem;
            Random random = new Random();
            for (int i = 0; i < l; i++)
            {

                elem = random.Next(l);
                tb.Push(findItem(elem) + "\r\n");
            }
            return tb;
        }
   
    private int findItem(int i)
    {
        int res = 0;
        if (arr[i] != min)
        {
            res = arr[i];
            arr[i] = min;
            return res;
        }
        else while (arr[i] == min)
            {
                i++;
                if (i == arr.Length) i = 0;

            }
        res = arr[i];
        arr[i] = min;
        return res;
    }
}
}
