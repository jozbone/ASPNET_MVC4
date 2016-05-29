using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncAwaitSamples
{
    [TestClass]
    public class DelaySamples
    {
        [TestMethod]
        public void Demonstrates_a_delay()
        {
            var task = SlowOperationAsync();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Slow operation result is: {0}", task.Result);
            Console.WriteLine("Slow operation test completed on {0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(2000);

            Console.WriteLine("Slow operation completed on {0}", Thread.CurrentThread.ManagedThreadId);

            return 42;
        }
    }    
}
