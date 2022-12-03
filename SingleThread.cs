using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core
{
    public class SingleThread
    {
        public TimeSpan Task1() 
        {
            DateTime start = DateTime.Now;

            float[] arr = new float[100_000_000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
                arr[i] = (float)(arr[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                Math.Cos(0.4f + i / 2));
            }

            DateTime finish = DateTime.Now;

            var result1 = finish - start;

            Console.WriteLine($"Инициализация массива в одном потоке заняла у нас:  {result1} сек.");
            Console.WriteLine();

            return result1;
        }
    }
}
