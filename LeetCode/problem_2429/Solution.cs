using Xunit;

namespace LeetCode.problem_2429;

public class Solution
{
  [Fact]
  public void Solution_Test1()
  {
    // Arrange
    var solution = new Solution();
    int A = 3;
    int B = 5;
    int expected = 3;

    // Act
    int result = solution.MinimizeXor(A, B);

    // Assert
    Assert.Equal(expected, result);
  }

  [Fact]
  public void Solution_Test2()
  {
    var solution = new Solution();
    // Arrange
    int A = 1;
    int B = 5;
    int expected = 3;

    // Act
    int result = solution.MinimizeXor(A, B);

    // Assert
    Assert.Equal(expected, result);
  }


  public int MinimizeXor(int num1, int num2)
  {

    int setBitsNum2 = CountSetBits(num2);
    int result = 0;

    // Attempt to create a number x starting from num1 with the same set bits as num2
    for (int i = 31; i >= 0 && setBitsNum2 > 0; i--)
    {
      if ((num1 & 1 << i) == 0)
        continue;

      result |= 1 << i;
      setBitsNum2--;
    }

    // If we still need more set bits, fill in the remaining from the LSB side
    for (int i = 0; i <= 31 && setBitsNum2 > 0; i++)
    {
      if ((result & 1 << i) != 0)
        continue;

      result |= 1 << i;
      setBitsNum2--;
    }

    return result;
  }

  // Function to count set bits in an integer
  private static int CountSetBits(int n)
  {
    int count = 0;
    while (n > 0)
    {
      count += n & 1;
      n >>= 1;
    }

    return count;
  }
}