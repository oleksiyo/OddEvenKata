using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OddEvenKata
{
    public class DigitServices : IDigitServices
    {
        readonly List<string> listResult = new List<string>();
        const string odd = "Odd";
        const string even = "Even";

        public IEnumerable<string> GetDigitTypeInRange(int startRange, int endRange)
        {
            for (var i = startRange; i <= endRange; i++)
            {
                listResult.Add(DetermineTypeOfDigit(i));
            }
            return listResult;
        }

        private static string DetermineTypeOfDigit(int input)
        {
            var dic = new Dictionary<Func<int, bool>, string>
            {
                {IsPrimeNumber, input.ToString()},
                {IsEvenNumber, even},
                {IsOddNumber, odd}
            };
            return dic.First(pair => pair.Key(input)).Value;
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
            return number != 1;
        }
    }

    public class DigitServicesTest
    {
        private DigitServices digitServices;
        public DigitServicesTest()
        {
            digitServices = new DigitServices();
        }

        [Fact]
        public void should_print_Odd_when_input_1()
        {
            var result = digitServices.GetDigitTypeInRange(1, 1);
            result.ShouldBeEquivalentTo(new List<string> { "Odd" });
        }

        [Fact]
        public void should_print_3_when_input_3()
        {
            var result = digitServices.GetDigitTypeInRange(3, 3);
            result.ShouldBeEquivalentTo(new List<string> { "3" });
        }

        [Fact]
        public void should_print_5_when_input_5()
        {
            var result = digitServices.GetDigitTypeInRange(5, 5);
            result.ShouldBeEquivalentTo(new List<string> { "5" });
        }

        [Fact]
        public void should_print_even_when_input_4()
        {
            var result = digitServices.GetDigitTypeInRange(4, 4);
            result.ShouldBeEquivalentTo(new List<string> { "Even" });
        }

        [Fact]
        public void should_print_odd_when_input_9()
        {
            var result = digitServices.GetDigitTypeInRange(9, 9);
            result.ShouldBeEquivalentTo(new List<string> { "Odd" });
        }

        [Fact]
        public void should_print_even_when_input_10()
        {
            var result = digitServices.GetDigitTypeInRange(10, 10);
            result.ShouldBeEquivalentTo(new List<string> { "Even" });
        }

        [Fact]
        public void should_return_odd_and_even()
        {
            var result = digitServices.GetDigitTypeInRange(8, 9);
            result.ShouldBeEquivalentTo(new List<string> { "Even", "Odd" });
        }

        [Fact]
        public void should_be_return_corect_string_in_range_1_10()
        {
            var result = digitServices.GetDigitTypeInRange(1, 10);
            result.ShouldBeEquivalentTo(new List<string> { "Odd", "2", "3", "Even", "5", "Even", "7", "Even", "Odd", "Even" });
        }

        [Fact]
        public void should_be_return_corect_string_in_range_1_20()
        {
            var result = digitServices.GetDigitTypeInRange(1, 20);
            result.ShouldBeEquivalentTo(new List<string> { "Odd", "2", "3", "Even", "5", "Even", "7", "Even", "Odd", "Even", "11", "Even", "13", "Even", "Odd", "Even", "17", "Even", "19", "Even" });
        }
    }
}
