using Xunit;

namespace LeetCode.problem_3223;

public class Solution
{
  [Fact]
  public void WordSubsets_Test1()
  {
    // Arrange
    var solution = new Solution();
    string s = "abaacbcbb";
    int expected = 5;

    // Act
    int result = solution.MinimumLength(s);

    // Assert
    Assert.Equal(expected, result);
  }

  [Fact]
  public void WordSubsets_Test3()
  {
    // Arrange
    var solution = new Solution();
    string s = "aa";
    int expected = 2;

    // Act
    int result = solution.MinimumLength(s);

    // Assert
    Assert.Equal(expected, result);
  }
  public int MinimumLength(string s)
  {
    if (s.Length <= 2) return s.Length;

    int[] freq = new int[26];
    foreach (char c in s)
    {
      freq[c - 'a']++;
    }


    int result = 0;
    for (int index = 0; index < freq.Length; index++)
    {
      if (freq[index] > 0)
      {
        result += freq[index] % 2 == 0 ?
          2 :
          1;
      }
    }

    return result;

  }
}