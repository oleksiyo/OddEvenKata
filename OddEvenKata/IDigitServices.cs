using System.Collections.Generic;

namespace OddEvenKata
{
  public  interface IDigitServices
  {
      IEnumerable<string> GetDigitTypeInRange(int startRange, int endRange);
  }
}
