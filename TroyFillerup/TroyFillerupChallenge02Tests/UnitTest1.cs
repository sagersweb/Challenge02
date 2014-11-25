using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TroyFillerupChallenge02;

namespace TroyFillerupChallenge02Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CashRegister_DollarAmount_ReturnCorrectChange()
        {
            double input = 289.42;
            Dictionary<double, int> expected = new Dictionary<double, int>() { 
                {100, 2},
                {50, 1},
                {20, 1},
                {10, 1},
                {5, 1},
                {1, 4},
                {.25, 1},
                {.10, 1},
                {.05, 1},
                {.01, 2}
            };
            var cashRegister = new CashRegister();

            var denominationArray = new List<double>() { 100, 50, 20, 10, 5, 1, .25, .10, .05, .01 };

            var output = cashRegister.GetChange(input, denominationArray);

            CollectionAssert.AreEqual(expected, output);
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CashRegister_NegativeAmount_ShouldThrowException()
        {
            double input = -100;

            var cashRegister = new CashRegister();

            var denominationArray = new List<double>() { 100, 50, 20, 10, 5, 1, .25, .10, .05, .01 };

            var output = cashRegister.GetChange(input, denominationArray);

            
        }
    }
}
