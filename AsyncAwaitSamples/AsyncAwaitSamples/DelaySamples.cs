﻿using System;
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

        [TestMethod]
        public void SomnezSampleInterviewQuestions_Score_XRayMachine()
        {
            var scorer = new Scorer();
            var result = scorer.CalculateScore("XRay Machine");
            Console.WriteLine(result);

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void SomnezSampleInterviewQuestions_Score_Jabbit()
        {
            var scorer = new Scorer();
            var result = scorer.CalculateScore("Jabbt");
            Console.WriteLine(result);

            Assert.AreEqual(13, result);
        }


        class Scorer
        {
            private Dictionary<char, int> scoreValues = new Dictionary<char, int>()
            {
                {'f', 3},
                {'j', 6},
                {'x', 12},
                {'a', 2},
                {'e', 2},
                {'i', 2},
                {'o', 2},
                {'t', 5},
            };

            public int CalculateScore(string input)
            {
                var sum = 0;

                foreach(var item in input.ToLower().ToCharArray())
                {
                    sum += ScoreCharacter(item);
                }

                return sum;
            }   
            
               
            private int ScoreCharacter(char c)
            {
                int characterValue = 0;

                if (this.scoreValues.ContainsKey(c))
                {
                    characterValue = this.scoreValues[c];
                }

                return characterValue;
            }
        }
    }    
}
