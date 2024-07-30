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

        public void Returns1GivenStringWith1(string numbers,int desiredResult)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }
    }




}