namespace StringCalc
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) 
                return 0;

            var result = numbers.Split(',')
                .Select(s => int.Parse(s))
                .Sum();

            return result;


        }

    }
}