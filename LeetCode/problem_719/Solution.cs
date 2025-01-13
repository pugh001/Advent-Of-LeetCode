using Xunit;

namespace LeetCode.problem_719;

public class Solution
{
  [Fact]
  public void SmallestDistancePair_Test1()
  {
    // Arrange
    var solution = new Solution();
    int[] nums = [1, 3, 1];
    const int k = 1;
    const int expected = 0;
    // Act
    int result = solution.SmallestDistancePair(nums, k);

    // Assert
    Assert.Equal(expected, result);
  }
    public int SmallestDistancePair(int[] nums, int k)
    {
      Array.Sort(nums);

      int n = nums.Length;
      int left = 0, right = nums[n - 1] - nums[0];

      // Step 2: Binary search for the k-th smallest distance
      while (left < right) {
        int mid = left + (right - left) / 2;
        if (CountPairs(mid, n, nums) >= k) {
          right = mid;
        } else {
          left = mid + 1;
        }
      }

      return left;

      // Helper function to count pairs with distance <= mid
    }
    private int CountPairs(int mid, int n, int[] nums)
    {
      int count = 0;
      int j = 0;

      for (int i = 0; i < n; i++) {
        while (j < n && nums[j] - nums[i] <= mid) {
          j++;
        }
        count += (j - i - 1);
      }

      return count;
    }
}