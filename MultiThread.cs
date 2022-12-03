using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core
{
    internal class MultiThread
    {
        public TimeSpan Task2()
        {
            DateTime start = DateTime.Now;

            float[] arr = new float[100_000_000];
            var firstHalf = arr.Take(arr.Length / 2).ToArray();
            var secondHalf = arr.Take(arr.Length / 2).ToArray();

            AutoResetEvent[] waitHandlers = new AutoResetEvent[2];
            for (int i = 0; i < waitHandlers.Length; i++)
            {
                waitHandlers[i] = new AutoResetEvent(false);
            }

            Thread thread1 = new Thread((o) =>
            {
                if (o != null && o is AutoResetEvent)
                {
                    for (int i = 0; i < firstHalf.Length; i++)
                    {
                        firstHalf[i] = 1;
                        firstHalf[i] = (float)(firstHalf[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                        Math.Cos(0.4f + i / 2));
                    }
                    ((AutoResetEvent)o).Set();
                }
            });
            thread1.Start(waitHandlers[0]);

            Thread thread2 = new Thread((o) =>
            {
                if (o != null && o is AutoResetEvent)
                {
                    for (int i = 0; i < secondHalf.Length; i++)
                    {
                        secondHalf[i] = 1;
                        secondHalf[i] = (float)(secondHalf[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                        Math.Cos(0.4f + i / 2));
                    }
                    ((AutoResetEvent)o).Set();
                }
            });
            thread2.Start(waitHandlers[1]);

            WaitHandle.WaitAll(waitHandlers);

            arr = firstHalf.Concat(secondHalf).ToArray();

            DateTime finish = DateTime.Now;

            var result2 = finish - start;

            Console.WriteLine($"Инициализация массива в двух потоках заняла у нас:  {result2} сек.");
            Console.WriteLine();

            return result2;
        }

        public TimeSpan Result(TimeSpan result) 
        {
            Console.WriteLine($"Два потока справились с задачей на {result - Task2()} секунд быстрее");
            return result;
        }
    }
}
