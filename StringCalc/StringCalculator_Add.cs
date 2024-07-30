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

        public void Returns1GivenEmptyStringWith1()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("1");

            Assert.Equal(1, result);


        }
    }




}