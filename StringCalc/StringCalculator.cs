using System;
using System.Linq;
using System.Collections.Generic;


namespace StringCalc

{
    public class StringCalculator
    {
        private int _callCount = 0;


        internal object Add(string numbers)
        {
            _callCount++;


            if (String.IsNullOrEmpty(numbers)) 
                return 0;

            var delimiters = new List<string> { ",", "\n" };

            string numberString = numbers;

           


            if (numberString.StartsWith("//"))
            {
                var endOfDelimiterIndex = numberString.IndexOf('\n');
                var delimiterSection = numberString.Substring(2, endOfDelimiterIndex - 2);
                numberString = numberString.Substring(endOfDelimiterIndex + 1);

                
                delimiters.AddRange(delimiterSection.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(d => !string.IsNullOrWhiteSpace(d))
                    .Select(d => d.Trim()));
            }


            var numberList = numberString.Split(delimiters.ToArray(), StringSplitOptions.None)
                            .Select(s => int.Parse(s))
                            .ToList();
           var negatives = numberList.Where(n => n < 0);

            if (negatives.Any())
            {
                string negativeString = String.Join(',', negatives.Select(n => n.ToString()));
                throw new Exception($"Negatives not allowed");

            }
            var result = numberList
                .Where(n => n <= 1000)
                .Sum();

            return result;

        }
        public int GetCalledCount()
        {
            return _callCount;
        }


    }
}