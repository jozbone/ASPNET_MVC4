using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncAwaitSamples
{
    [TestClass]
    public class PiMatch
    {
        [TestMethod]
        public void CalculatePiMatchScore_3149()
        {
            
//            int[] input = {3, 1, 4, 9};

            int input = 3149;
            var calculator = new PiMatchCalculator();
            var result = calculator.Score(input);

            Console.WriteLine(result);
            Assert.AreEqual(-82.5, result);
        }

        [TestMethod]
        public void CalculatePiMatchScore_357878()
        {
//            int[] input = { 3, 5, 7, 8, 7, 8 };
            int input = 357878;

            var calculator = new PiMatchCalculator();
            var result = calculator.Score(input);

            Console.WriteLine(result);
            Assert.AreEqual(336, result);
        }

    }

    internal class PiMatchCalculator
    {
        private const int frameLength = 3;
        private const double piApprox = 314;

        public double Score(int input)
        {
            int[] inputAsArray = ConvertToArray(input);

            return Score(inputAsArray);
        }

        private int[] ConvertToArray(int input)
        {
            if (input == 0) return new[] {0};

            var digits = new List<int>();
            int positionOfTens = 10;

            for (; input > 0; input /= 10)
            {
                digits.Add(input % positionOfTens);    
            }

            var result = digits.ToArray();
            Array.Reverse(result);
            return result;
        }

        public double Score(int[] input)
        {
            if (!IsValidLength(input))
            {
                return 0;
            }

            return CalculateScore(input);
        }

        private double CalculateScore(int[] input)
        {
            double score = 0;
            int currentPosition = 0;

            while ((input.Length - currentPosition) >= frameLength)
            {
                int pos1 = input[currentPosition] * 100;
                int pos2 = input[currentPosition + 1] * 10;
                int pos3 = input[currentPosition + 2] * 1;

                int valueToCompare = pos1 + pos2 + pos3;
                score += valueToCompare - piApprox;
                currentPosition++;
            }

            return score/((input.Length - frameLength) + 1);
        }

        private bool IsValidLength(int[] input)
        {
            return input.Length >= frameLength;
        }
    }
}