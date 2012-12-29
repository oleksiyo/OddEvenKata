using FluentAssertions;
using Xunit;

namespace OddEvenKata
{
    public class OddEven
    {
        const string odd = "Odd";
        const string even = "Even";

        public string PrintNumbersInRange(int startRange, int endRange)
        {
            var result = string.Empty;
            for (var i = startRange; i <= endRange; i++)
            {
                if (i > startRange)
                    result += " ";

                if (IsPrimeNumber(i))
                    result += i.ToString();

                if (IsEvenNumber(i))
                    result += even;

                if (IsOddNumber(i))
                    result += odd;
            }
            return result;
        }

        private static bool IsOddNumber(int number)
        {
            if (IsPrimeNumber(number))
                return false;

            return number % 2 != 0;
        }

        private static bool IsEvenNumber(int number)
        {
            return number > 2 && number % 2 == 0;
        }

        private static bool IsPrimeNumber(int number)
        {
            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return number == 1 ? false : true;
        }
    }



    public class OddEvenTest
    {
        private readonly OddEven oddEven;
        public OddEvenTest()
        {
            oddEven = new OddEven();
        }
        [Fact]
        public void should_print_Odd_when_input_1()
        {
            var result = oddEven.PrintNumbersInRange(1, 1);
            result.Should().Be("Odd");
        }

        [Fact]
        public void should_print_3_when_input_3()
        {
            var result = oddEven.PrintNumbersInRange(3, 3);
            result.Should().Be("3");
        }

        [Fact]
        public void should_print_5_when_input_5()
        {
            var result = oddEven.PrintNumbersInRange(5, 5);
            result.Should().Be("5");
        }

        [Fact]
        public void should_print_even_when_input_4()
        {
            var result = oddEven.PrintNumbersInRange(4, 4);
            result.Should().Be("Even");
        }

        [Fact]
        public void should_print_odd_when_input_9()
        {
            var result = oddEven.PrintNumbersInRange(9, 9);
            result.Should().Be("Odd");
        }

        [Fact]
        public void should_print_even_when_input_10()
        {
            var result = oddEven.PrintNumbersInRange(10, 10);
            result.Should().Be("Even");
        }

        [Fact]
        public void should_return_odd_and_even()
        {
            var result = oddEven.PrintNumbersInRange(8, 9);
            result.Should().Be("Even Odd");
        }

        [Fact]
        public void should_be_return_corect_string_in_range_1_10()
        {
            var result = oddEven.PrintNumbersInRange(1, 10);
            result.Should().Be("Odd 2 3 Even 5 Even 7 Even Odd Even");
        }
    }

}
