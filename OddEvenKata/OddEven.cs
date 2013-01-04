using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace OddEvenKata
{
    public class OddEven
    {
        private readonly IDigitServices digitServices;

        public OddEven(IDigitServices digitServices)
        {
            this.digitServices = digitServices;
        }

        public string PrintNumbersInRange(int startRange, int endRange)
        {
            var listTypeNumbers = digitServices.GetDigitTypeInRange(startRange, endRange);
            return string.Join(" ", listTypeNumbers);
        }
    }

    public class OddEvenTest
    {
        private readonly OddEven oddEven;
        readonly IDigitServices digitServices = Substitute.For<IDigitServices>();
        public OddEvenTest()
        {
            oddEven = new OddEven(digitServices);
        }

        [Fact]
        public void should_be_Odd_when_input_1()
        {
            digitServices.GetDigitTypeInRange(1,1)
                .Returns(new List<string> { "Odd" });
            var result = oddEven.PrintNumbersInRange(1, 1);
            result.Should().Be("Odd");
        }

        [Fact]
        public void should_be_corect_string_in_range_1_10()
        {
            digitServices.GetDigitTypeInRange(1, 10)
              .Returns(new List<string> { "Odd","2","3","Even","5","Even","7","Even","Odd","Even" });

            var result = oddEven.PrintNumbersInRange(1, 10);
            result.Should().Be("Odd 2 3 Even 5 Even 7 Even Odd Even");
        }

        [Fact]
        public void should_be_string_in_range_1_20()
        {
            digitServices.GetDigitTypeInRange(1, 20)
              .Returns(new List<string> { "Odd", "2", "3", "Even", "5", "Even", "7", "Even", "Odd", "Even", "11", "Even", "13", "Even", "Odd", "Even", "17", "Even", "19", "Even" });
            var result = oddEven.PrintNumbersInRange(1, 20);
            result.Should().Be("Odd 2 3 Even 5 Even 7 Even Odd Even 11 Even 13 Even Odd Even 17 Even 19 Even");
        }
    }
}
