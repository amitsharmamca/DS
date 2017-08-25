using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation
{
    public static class Array
    {
        public static bool IsPalindrome(int[] input)
        {
            int front = 0;
            int rear = input.Length - 1;
            while (front < rear)
            {
                if (input[front] != input[rear])
                {
                    return false;
                }
                front++; rear--;
            }
            return true;
        }

        public static bool IsPalindrome1(int[] input)
        {
            for(int i=0; i<=((input.Length/2)-1); i++)
            {
                if(input[i] != input[input.Length-i-1])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method calculates product of left number and right number in a given array. Ex: input = {1,2,5,6} , output = {60,30,12,10}
        /// </summary>
        /// <param name="input">Integer array</param>
        /// <returns>Integer Array</returns>
        public static int[] LeftRightMulitply(int[] input)
        {
            int[] output = new int[input.Length];

            for(int i=0; i<input.Length;i++)
            {
                int LeftNum =1 , RightNum =1;
                
                for(int j=i-1; j>=0; j--)
                    LeftNum *= input[j];
                
                for(int k=i+1; k<input.Length; k++)
                    RightNum *= input[k];
                
                output[i] = LeftNum * RightNum;
            }
            return output;
        }

        /// <summary>
        /// This method calculates product of left number and right number in a given array. Ex: input = {1,2,5,6} , output = {60,30,12,10}
        /// </summary>
        /// <param name="input">Integer array</param>
        /// <returns>Integer Array</returns>
        public static int[] LeftRightMulitplyModularized(int[] input)
        {
            int[] result = new int[input.Length];

            for(int i=0; i<input.Length;i++)
            {
                result[i] = Multiply(input, 0, i - 1) * Multiply(input, i + 1, input.Length - 1);
            }
            return result;
        }

        private static int Multiply(int[] arr, int StartIndex, int EndIndex)
        {
            int result = 1;
            if(EndIndex <0 || StartIndex >= arr.Length)
            {
                return 1;
            }
            for (int i = StartIndex; i <= EndIndex; i++)
            {
                result *= arr[i];
            }
            return result;
        }

        public static List<int[]> getCombinations(int[] arr, int sum)
        {
            List<int[]> returningList = new List<int[]>();

            int addition = 0;

            for(int front=0; front<arr.Length;front++)
            {
                for(int end=front; end<arr.Length;end++)
                {
                    addition = Add(arr, front, end);
                    if(addition == sum)
                    {
                        returningList.Add(CopyArr(arr, front, end));
                    }
                }
            }
            return returningList;
        }

        private static int Add(int[] arr, int front, int end)
        {
            int total = 0;
            for(int i=front; i<=end;i++)
            {
                total += arr[i];
            }
            return total;
        }

        private static int[] CopyArr(int[] inputArray, int StartIndex, int EndIndex)
        {
            int[] Output = new int[(EndIndex - StartIndex)+1];
            int j=0;
            for(int i=StartIndex; i<=EndIndex;i++)
            {
                Output[j] = inputArray[i];
                j++;
            }
            return Output;
        }

        public static List<int[]> getCombinations1(int[] a, int s)
        {
            List<int[]> returningList = new List<int[]>();
            
            for(int i=0; i<a.Length;i++)
            {
                int c = 0;
                for(int j=i; j<a.Length;j++)
                {
                    c = c + a[j];
                    if (c == s)
                       returningList.Add(CopyArr(a, i, j));
                }
            }
            return returningList;
        }


    }
}
