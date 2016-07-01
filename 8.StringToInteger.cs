using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringtoInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Solution sol = new Solution();
            do
            {
                input = Console.ReadLine();
                Console.WriteLine(sol.MyAtoi(input));
            } while (input != "#");
        }
    }

    public class Solution
    {
        /// <summary>
        /// convert a string to an integer.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>
        /// if string is empty or is not a valid number, 0 is returned.
        /// if overflow happens, INT_MAX or INT_MIN is returned.
        /// </returns>
        public int MyAtoi(string str)
        {
            string num = str.TrimStart(' ', '\t', '\n');  // discard leading whitespace  characters. 

            if (string.IsNullOrEmpty(num))
            {
                // if str is empty, then return 0.
                return 0;
            }

            bool isNegative = false;  // indicates if this integer is negative.
            int i = 0;
            if (num[i] == '+')
            {
                ++i;
            }
            else if (num[i] == '-')
            {
                isNegative = true;
                ++i;
            }

            try
            {
                int result = 0;
                while (i < num.Length && char.IsDigit(num[i]))
                {
                    if (isNegative)
                    {
                        result = checked(result * 10 - (num[i] - '0'));
                    }
                    else
                    {
                        result = checked(result * 10 + (num[i] - '0'));
                    }
                    ++i;
                }

                return result;
            }
            catch (OverflowException)  // overflow happens.
            {
                if (isNegative)
                    return int.MinValue;
                else
                    return int.MaxValue;
            }
        }
    }
}
