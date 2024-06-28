using System;
using System.Collections.Generic;

namespace intresting_sarzamin
{
    class Program
    {
        static long Func1(long[] arr,long index1,long index2)
        {
            long minvalue = arr[index1];
            long count = 0; 

            for (long i = index1 + 1; i <= index2; i++)
            {
                minvalue = Math.Min(minvalue, arr[i]);
                count++;
            }

            if(minvalue >= count+1)
            {
                for (long k = index1; k <= index2; k++)
                {
                    arr[k] = 0;
                }
                return count + 1;
            }
            else
            {
                for (long c = index1; c <= index2; c++)
                {
                    arr[c] -= minvalue;
                }
                return minvalue;
            }
        }

        static long khalamoo(long[] arr,long n)
        {
            long j = 0; long final = 0; long i;
            while(j<n)
            {
                if (arr[j] != 0)
                {
                    i = j + 1;
                    while (arr[i] != 0 && i < n)
                    {
                        i++;
                        if (i >= n)
                            break;
                        //Console.WriteLine(i);
                    }
                    //Console.WriteLine(j);
                    //Console.WriteLine(i - 1);
                    final += Func1(arr, j, i - 1);
                    j = i;
                }

                else
                    j++;
            }
            return final;
        }
        static void Main(string[] args)
        {
            long final = 0;
            long n = Convert.ToInt64(Console.ReadLine());
            string[] tokens = Console.ReadLine().Split();
            long[] array = new long[n];
            for(long i=0 ; i<n ;i++)
            {
                array[i] = Convert.ToInt64(tokens[i]);
            }
            while(true)
            {
                long count = khalamoo(array, array.Length);
                if(count == 0)
                {
                    break;
                }
                else
                {
                    final += count;
                }
            }
            if(final > n)
                Console.WriteLine(n);
            else
                Console.WriteLine(final);
        }
    }
}
