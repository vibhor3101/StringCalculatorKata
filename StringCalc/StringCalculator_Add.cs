using System;
using Xunit;

namespace StringCalc
{

    public class StringCalculator_Add
    {
        [Fact]
        public void Returns0GivenEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);


        }


        [Theory]
        [InlineData("1",1)]
        [InlineData("2", 2)]


        public void ReturnsNumberGivenStringWithOneNumber(string numbers,int desiredResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }


        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]



        public void ReturnsSumGivenStringWithTwoCommaSeparatedNumbers(string numbers, int desiredResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }
    }




}