using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            new Solution().Rotate(arr, 2);
            foreach (int num in arr)
                Console.WriteLine(num);
        }
    }

    public class Solution
    {
        /// <summary>
        /// Rotate an array of n elements to the right by k steps.
        /// </summary>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
                return;
            k = k % nums.Length;
            // simply copy elements to proper position in another array.
            int[] rotatedNums = new int[nums.Length];
            int dest = k;
            for (int index = 0; index != nums.Length; ++index)
            {
                rotatedNums[dest] = nums[index];
                ++dest;
                if (dest == nums.Length)
                    dest = 0;
            }
            
            // then copy elements back.
            for (int index = 0; index != rotatedNums.Length; ++index)
            {
                nums[index] = rotatedNums[index];
            }
        }
    }

    public class AnotherSolution
    {
        /// <summary>
        /// Yet another solution to this question.
        /// Rotate an array of n elements to the right by k steps in place.
        /// </summary>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
                return;

            k = k % nums.Length;

            int limit = gcd(nums.Length, k);
            for (int i = 0; i != limit; ++i)
            {
                int j = (i + k) % nums.Length;
                int temp = nums[j];
                nums[j] = nums[i];

                while (j != i)
                {
                    int t = (j + k) % nums.Length;

                    int temp2 = nums[t];
                    nums[t] = temp;
                    temp = temp2;

                    j = t;
                }
            }
        }

        private int gcd(int a, int b)
        {
            while (b != 0)
            {
                int t = a;
                a = b;
                b = t % b;
            }
            return a;
        }
    }
}
