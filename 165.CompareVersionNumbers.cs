using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareVersionNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string ver1, ver2;
            do
            {
                ver1 = Console.ReadLine();
                ver2 = Console.ReadLine();
                Console.WriteLine(sol.CompareVersion(ver1, ver2));
            } while (ver1 != "#");
        }
    }

    public class Solution
    {
        /// <summary>
        /// Compare two version numbers version1 and version2.
        /// A version number is a string contains only dot and digits.
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns> returns 1 if version1 > version 2, -1 if version2 > version 1,
        /// and 0 otherwise </returns>
        public int CompareVersion(string version1, string version2)
        {
            // first split both version number by '.'
            string[] versionSegs1 = removeTailing0(version1.Split('.'));
            string[] versionSegs2 = removeTailing0(version2.Split('.'));

            int index = 0;
            while (index < versionSegs1.Length && index < versionSegs2.Length)
            {
                int order = compareInteger(versionSegs1[index], versionSegs2[index]);
                if (order < 0)
                    return -1;
                else if (order > 0)
                    return 1;
                ++index;
            }

            // now at least one end of the two versions has been met.
            if (index == versionSegs1.Length && index == versionSegs2.Length)
                return 0;
            else if (index < versionSegs1.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// compares two non-negative integers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns> returns 1 if num1 > num2, -1 is num2 > num1, and 0 if equal. </returns>
        private int compareInteger(string num1, string num2)
        {
            num1 = num1.TrimStart('0');
            num2 = num2.TrimStart('0');
            if (num1.Length < num2.Length)
            {
                return -1;
            }
            else if (num1.Length > num2.Length)
            {
                return 1;
            }
            else
            {
                // the two integers are of same length.
                return string.CompareOrdinal(num1, num2);
            }
        }

        private string[] removeTailing0(string[] arr)
        {
            Stack<string> strStack = new Stack<string>(arr);
            while (strStack.Count != 1)
            {
                if (string.IsNullOrEmpty(strStack.Peek().TrimStart('0')))
                {
                    // if the last element of the list is a string contains only 0s.
                    strStack.Pop();
                }
                else
                    break;
            }
            arr = strStack.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}
