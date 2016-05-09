using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new IComparable[100];
            var rd = new Random();
            for (var i = 0; i < arr.Length; ++i)
                arr[i] = rd.Next(1, 101);
            Console.WriteLine("Массив перед сортировкой:");
            foreach (var x in arr)
                Console.Write(x + " ");

            arr = Merge_Sort(arr);
            Console.WriteLine("\n\nМассив после сортировки:");
            foreach (var x in arr)
                Console.Write(x + " ");
            Console.WriteLine("\n\nДля выхода нажмите <Enter>.");
            Console.ReadKey();

            
        }

        //предыдущий пример сортирует лишь целые числа. Следующий - работает со всеми типами данных. 
        static IComparable[] Merge_Sort(IComparable[] massive)
        {
            if (massive.Length == 1)
                return massive;
            var mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        static IComparable[] Merge(IComparable[] mass1, IComparable[] mass2)
        {
            int a = 0, b = 0;
            var merged = new IComparable[mass1.Length + mass2.Length];
            for (var i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b.CompareTo(mass2.Length) < 0 && a.CompareTo(mass1.Length) < 0)
                    if (mass1[a].CompareTo(mass2[b]) > 0)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

    }
    

}
