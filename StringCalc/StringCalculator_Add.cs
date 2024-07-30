using System;
using Xunit;

namespace StringCalc
{

    public class StringCalculator_Add
    {
        private StringCalculator _calculator = new StringCalculator();


        [Fact]
        public void Returns0GivenEmptyString()
        {

            var result = _calculator.Add("");

            Assert.Equal(0, result);


        }


        [Theory]
        [InlineData("1",1)]
        [InlineData("2", 2)]


        public void ReturnsNumberGivenStringWithOneNumber(string numbers,int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }


        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]



        public void ReturnsSumGivenStringWithTwoCommaSeparatedNumbers(string numbers, int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }



        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("6,7,8", 21)]

        public void ReturnsSumGivenStringWithThreeCommaSeparatedNumbers(string numbers, int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }
    }
}