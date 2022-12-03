using System.Threading;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            SingleThread singleThread = new SingleThread();

            MultiThread multiThread = new MultiThread();

            multiThread.Result(singleThread.Task1());
        }
    }
}