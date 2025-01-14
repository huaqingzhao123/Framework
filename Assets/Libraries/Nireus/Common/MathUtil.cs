﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Nireus
{
    public static class MathUtil
    {

        //ret [min, max)
        /// <summary>
        /// 结果只包含min和max-1的值。
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        //public static int random(int min, int max)
        //{
        //    //return (int)RandomService.Range((int)RandomType.Common,min,max - 0.1f);
        //    //return new Random().Next(min, max);
        //}

        public static int max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static int min(int a, int b)
        {
            return a < b ? a : b;
        }

        public static int ceil(double value)
        {
            return (int)Math.Ceiling(value);
        }

        public static int floor(double value)
        {
            return (int)Math.Floor(value);
        }

        /// <summary>
        /// 初始化权重值，如10%，50%，40为 {100,500,400}，和必须等于1000
        /// </summary>
        /// <param name="weight"></param>
        public static int[] getRandomWeightIndex(int[] weight)
        {
            int[] index_weight = new int[1000];
            int counter = 0;
            for (int i = 0; i < weight.Length; i++)
            {
                int c = weight[i];
                for (int j = 0; j < c; j++)
                {
                    index_weight[counter] = i;
                    counter++;
                }
            }
            if (counter < 1000)
            {
                throw new Exception("百分比分配不足1000");
            }
            return index_weight;
        }

        /// <summary>
        /// 按计算好后的权重随机函数，使用前先setRandomWeight初始化得到weight_index_array。
        /// </summary>
        /// <returns></returns>
        //public static int randomWeight(int[] weight_index_array)
        //{
        //    int index = random(0, weight_index_array.Length);
        //    return 0/*weight_index_array[index]*/;
        //}

        public static string MD5(string encrypt_string)
        {
            if (string.IsNullOrEmpty(encrypt_string)) throw new System.Exception("encrypt_string is null.");
            return MD5(Encoding.Default.GetBytes(encrypt_string));
        }

        public static string MD5(byte[] encrypte_data)
        {
            string md5_str = string.Empty;
            if (encrypte_data == null) throw new System.Exception("encrypt_string is null.");
            MD5 md5_class = new MD5CryptoServiceProvider();
            md5_str = System.BitConverter.ToString(md5_class.ComputeHash(encrypte_data)).Replace("-", "");
            return md5_str;
        }

        #region Static Fields

        static readonly int[] __log2_32 = new int[32]
        {
            0,   9,  1, 10, 13, 21, 2, 29,
            11, 14, 16, 18, 22, 25, 3, 30,
            8,  12, 20, 28, 15, 17, 24, 7,
            19, 27, 23,  6, 26,  5,  4, 31
        };

        static readonly int[] __log2_64 = new int[64]
        {
            63,  0, 58,  1, 59, 47, 53,  2,
            60, 39, 48, 27, 54, 33, 42,  3,
            61, 51, 37, 40, 49, 18, 28, 20,
            55, 30, 34, 11, 43, 14, 22,  4,
            62, 57, 46, 52, 38, 26, 32, 41,
            50, 36, 17, 19, 29, 10, 13, 21,
            56, 45, 25, 31, 35, 16,  9, 12,
            44, 24, 15,  8, 23,  7,  6,  5
        };

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Returns true if the input value is an integer power of two.
        /// </summary>
        /// <param name="x">The value to test.</param>
        /// <returns>True if the input value is an integer power of two; otherwise false.</returns>
        public static bool IsPowerOfTwo(int x)
        {
            // From: https://stackoverflow.com/questions/600293/how-to-check-if-a-number-is-a-power-of-2
            return (x != 0) && (x & (x - 1)) == 0;
        }

        /// <summary>
        /// Returns true if the input value is an integer power of two.
        /// </summary>
        /// <param name="x">The value to test.</param>
        /// <returns>True if the input value is an integer power of two; otherwise false.</returns>
        public static bool IsPowerOfTwo(long x)
        {
            // From: https://stackoverflow.com/questions/600293/how-to-check-if-a-number-is-a-power-of-2
            return (x != 0) && (x & (x - 1)) == 0;
        }

        /// <summary>
        /// Calculates two to the power of the given integer exponent.
        /// </summary>
        /// <param name="exponent">The integer exponent (0 &lt;= exponent &lt; 31)</param>
        public static int PowerOfTwo(int exponent)
        {
            if (exponent < 0 || exponent > 30)
            {
                throw new ArgumentOutOfRangeException("exponent");
            }
            return 1 << exponent;
        }

        /// <summary>
        /// Calculates two to the power of the given long integer exponent.
        /// </summary>
        /// <param name="exponent">The long integer exponent (0 &lt;= exponent &lt; 63)</param>
        public static long PowerOfTwo(long exponent)
        {
            if (exponent < 0 || exponent > 62)
            {
                throw new ArgumentOutOfRangeException("exponent");
            }
            return 1L << (int)exponent;
        }

        /// <summary>
        /// Returns the smallest power of two that is greater than or equal to the specified number.
        /// </summary>
        /// <returns>The smallest integral power of two that is greater than or equal to x.</returns>
        public static int CeilingToPowerOfTwo(int x)
        {
            // Test for max input value. There is one more high bit, but that is the sign bit.
            if (x < 0 || x > 0x40000000)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            // From: https://stackoverflow.com/questions/466204/rounding-up-to-next-power-of-2
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x + 1;
        }

        /// <summary>
        /// Returns the smallest power of two that is greater than or equal to the specified number.
        /// </summary>
        /// <returns>The smallest integral power of two that is greater than or equal to x.</returns>
        public static long CeilingToPowerOfTwo(long x)
        {
            // Test for max input value. There is one more high bit, but that is the sign bit.
            if (x < 0 || x > 0x4000000000000000)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            // From: https://stackoverflow.com/questions/466204/rounding-up-to-next-power-of-2
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;
            return x + 1;
        }

        /// <summary>
        /// Evaluate the binary logarithm of a non-zero Int32.
        /// </summary>
        /// <remarks>Two-step method using a De Bruijn-like sequence table lookup.</remarks>
        public static int Log2(uint x)
        {
            // ENHANCEMENT: Use Lzcnt.LeadingZeroCount intrinsic.
            // Method from: https://stackoverflow.com/a/11398748/15703
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return __log2_32[(x * 0x07C4ACDDU) >> 27];
        }

        /// <summary>
        /// Evaluate the binary logarithm of a non-zero Int64.
        /// </summary>
        /// <remarks>Two-step method using a De Bruijn-like sequence table lookup.</remarks>
        public static int Log2(ulong x)
        {
            // ENHANCEMENT: Use Lzcnt.LeadingZeroCount intrinsic.
            // Method from: https://stackoverflow.com/a/11398748/15703
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return __log2_64[(((x - (x >> 1)) * 0x07EDD5E59A4E28C2)) >> 58];
        }

        /// <summary>
        /// Evaluate the binary logarithm of a non-zero Int32, with rounding up of fractional results.
        /// I.e. returns the exponent of the smallest power of two that is greater than or equal to the specified number.
        /// </summary>
        /// <returns>The exponent of the smallest integral power of two that is greater than or equal to x.</returns></returns>
        public static int Log2Ceiling(uint x)
        {
            // Log2(x) gives the required power of two, however this is integer Log2() therefore any fractional
            // part in exp is truncated, i.e. the result may be 1 too low. Thus, if 2^exp == x, then x is an exact 
            // power of two and exp is correct, otherwise exp + 1 gives the correct value.
            int exp = Log2(x);

            // Calc x1 = 2^exp
            int x1 = 1 << exp;

            // Return exp + 1 if x is not an exact power of two.
            return (x == x1) ? exp : exp + 1;
        }

        /// <summary>
        /// Evaluate the binary logarithm of a non-zero Int32, with rounding up of fractional results.
        /// I.e. returns the exponent of the smallest power of two that is greater than or equal to the specified number.
        /// </summary>
        /// <returns>The exponent of the smallest integral power of two that is greater than or equal to x.</returns></returns>
        public static int Log2Ceiling(ulong x)
        {
            // Log2(x) gives the required power of two, however this is integer Log2() therefore any fractional
            // part in exp is truncated, i.e. the result may be 1 too low. Thus, if 2^exp == x, then x is an exact 
            // power of two and exp is correct, otherwise exp+1 gives the correct value.
            int exp = Log2(x);

            // Calc x1 = 2^exp
            ulong x1 = 1UL << exp;

            // Return exp + 1 if x is not an exact power of two.
            return (x == x1) ? exp : exp + 1;
        }

        /// <summary>
        /// Returns the number of leading zeroes in the binary representation of the given value.
        /// </summary>
        public static int LeadingZeroCount(uint x)
        {
            // ENHANCEMENT: Use Lzcnt.LeadingZeroCount intrinsic.
            if (x == 0)
            {
                return 32;
            }

            return 32 - (Log2(x) + 1);
        }

        /// <summary>
        /// Returns the number of leading zeroes in the binary representation of the given value.
        /// </summary>
        public static int LeadingZeroCount(ulong x)
        {
            // ENHANCEMENT: Use Lzcnt.LeadingZeroCount intrinsic.
            if (x == 0)
            {
                return 64;
            }

            return 64 - (Log2(x) + 1);
        }

        #endregion
    }
}
