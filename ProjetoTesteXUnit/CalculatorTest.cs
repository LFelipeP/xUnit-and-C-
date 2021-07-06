using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ProjetoTesteXUnit
{
    public class CalculatorTest
    {
        private readonly Calculator calc;

        public CalculatorTest()
        {
            calc = new Calculator();
        }

        [Fact]
        public void AddTwoNumbersShouldEqualTheirEqual()
        {
            calc.Add(5);
            calc.Add(8);
            Assert.Equal(13, calc.Value);
        }

        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(10, 5, 5)]
        [InlineData(1, 6, -5)]
        public void AddTwoNumbersShouldEqualTheirEqualTheory(decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            calc.Add(firstToAdd);
            calc.Add(secondToAdd);
            Assert.Equal(expected, calc.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddTwoNumbersShouldEqualTheirEqualMemberDataTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach(var value in valuesToAdd)
            {
                calc.Add(value);
            }
            Assert.Equal(expected, calc.Value);
        }

        [Theory]
        [ClassData(typeof(MultiplyTestData))]
        public void DivideManyNumbersTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                calc.Multiply(value);
            }
            Assert.Equal(expected, calc.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { 30, new decimal[] { 10, 5, 15 } };
        }
    }

    public class MultiplyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 120, new decimal[] { 60, 2 } };
            yield return new object[] { 150, new decimal[] { 30, 5 } };
            yield return new object[] { 25, new decimal[] { 5, 5 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
