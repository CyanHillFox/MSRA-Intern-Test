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
        }
    }

    public class Solution
    {
        /// <summary>
        /// Rotate an array of n elements to the right by k steps.
        /// </summary>
        public void Rotate(int[] nums, int k)
        {
            // simply copy elements to proper position in another array.
            int[] rotatedNums = new int[nums.Length];
            for (int index = 0; index != nums.Length; ++index)
            {
                rotatedNums[(index + k) % nums.Length] = nums[index];
            }
            
            // then copy elements back.
            for (int index = 0; index != rotatedNums.Length; ++index)
            {
                nums[index] = rotatedNums[index];
            }
        }
    }
}
