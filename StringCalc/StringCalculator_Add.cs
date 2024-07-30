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



        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("6\n7\n8", 21)]
        [InlineData("1,1\n1", 3)]


        public void ReturnsSumGivenStringWithThreeCommaOrNewLineSeparatedNumbers(string numbers, int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }



        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        
        public void ReturnsSumGivenStringWithCustomDelimiter(string numbers, int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);
        }





        [Theory]
        [InlineData("-1,2","Negatives not allowed")]
        [InlineData("-1,-2", "Negatives not allowed")]

        public void ThrowsGivenNegativeInputs(string numbers, string desiredMessage)
        {
            Action action = () =>  _calculator.Add(numbers);

            var ex = Assert.Throws<Exception>(action);

            Assert.Equal(desiredMessage, ex.Message);


        }

        [Fact]
        public void GetCalledCount_ReturnsZeroInitially()
        {
            
            int count = _calculator.GetCalledCount();

            
            Assert.Equal(0, count);
        }

        [Fact]
        public void GetCalledCount_ReturnsOneAfterOneAddCall()
        {
            
            _calculator.Add("1");
            int count =  _calculator.GetCalledCount();

            
            Assert.Equal(1, count);
        }

        [Fact]
        public void GetCalledCount_ReturnsCorrectCountAfterMultipleAddCalls()
        {
            
            _calculator.Add("1");
            _calculator.Add("2");
            _calculator.Add("3");
            int count = _calculator.GetCalledCount();

            
            Assert.Equal(3, count);
        }


        [Theory]
        [InlineData("1,2,3000", 3)]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]


        public void ReturnsSumGivenStringIgnoringValuesOver1000(string numbers, int desiredResult)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(desiredResult, result);


        }




        

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        
        public void ReturnsSumGivenStringWithCustomDelimiters(string numbers, int desiredResult)
        {
            var result = _calculator.Add(numbers);
            Assert.Equal(desiredResult, result);
        }


        [Theory]

        [InlineData("//[***][%%%]\n1***2%%%3", 6)]
        public void ReturnsSumGivenStringWithMultipleCustomDelimiters(string numbers, int desiredResult)
        {
            var result = _calculator.Add(numbers);
            Assert.Equal(desiredResult, result);
        }







        [Theory]
        [InlineData("//[**][%%]\n1**2%%3", 6)]
        public void ReturnsSumGivenStringWithMultipleCustomDelimitersOfLengthLongerThanOneChar(string numbers, int desiredResult)
        {
            var result = _calculator.Add(numbers);
            Assert.Equal(desiredResult, result);
        }




        [Fact]
        public void AddOccuredEventIsTriggerOnAdd()
        {

            string recvInput = null;
            int recvResult = 0;
            _calculator.AddOccured += (input, result) =>
            {
                recvInput = input;
                recvResult = result;
            };


            var result = _calculator.Add("5,5");


            Assert.Equal("5,5", recvInput);
            Assert.Equal(10, recvResult);
        }





    }
}