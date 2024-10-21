using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 5;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                IList<int> missingNumbers = new List<int>();
                //Initializing the listfor storing missing numbers.
                for (int i = 0; i < nums.Length; i++)
                {
                  //Marking the  numbers by negating the value at the index corresponding to the number
                    int index = Math.Abs(nums[i]) - 1;
                    //If the number at index is positive,it would be negated to mark it.
                    if (nums[index] > 0)
                    
                    { nums[index] = -nums[index]; }
                    
                }
                //TO FInd rmeining positive indices
                for (int i = 0; i < nums.Length; i++)
                {
                    //missed values indicate positve numbers
                    if (nums[i] > 0)
                    {
                        missingNumbers.Add(i + 1);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                //a new array to store sorted result
                int[] result = new int[nums.Length];
                int start = 0, end = nums.Length - 1;
                //sorting the elements in array such that even numbers preceede odd numbers
                foreach (var num in nums)

                    //if even placed at the start else place at the end
                {
                    
                    if (num % 2 == 0)
                    {
                        result[start++] = num;
                    }
                    else
                    
                        { result[end--] = num; }
                    
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                //dictionary to stor the numbers and indices
                Dictionary<int, int> dict = new Dictionary<int, int>();
                //Interating through the array to find two numbers that add to target
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    //to check if a compliment exists
                    if (dict.ContainsKey(complement))
                    {
                        return new int[] { dict[complement], i };
                    }
                    dict[nums[i]] = i;
                }

                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // Check if the input array is null
            if (nums == null)
            {
                //exception if the array is null
                throw new ArgumentNullException(nameof(nums), "Input array cannot be null");
            }

            // Check if the array has at least 3 elements
            if (nums.Length < 3)
            {
              
                throw new ArgumentException("Array must contain at least 3 elements");
            }

            // Sort the array in ascending order to find the largest and smallest numbers
            Array.Sort(nums);

            // Get the length of the array
            int n = nums.Length;

            // Calculate the maximum product by :
            // 1. Product of the three largest numbers
            // 2. Product of the two smallest (which might be negative) and the largest number
            return Math.Max(
                nums[n - 1] * nums[n - 2] * nums[n - 3],
                nums[0] * nums[1] * nums[n - 1]
            );
        
    }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int inputNumber)
        {
            // Check if the input number is negative
            if (inputNumber < 0)
            {
                // Throw an exception if the input is negative
                throw new ArgumentException("Input must be a non-negative integer.");
            }

            // Special case for zero
            if (inputNumber == 0)
            {
                // Return "0" directly for zero
                return "0";
            }

            string binaryResult = "";

            // Convert the integer number to binary using repeated division by 2
            while (inputNumber > 0)
            {
                // Get the remainder when divided by 2 (0 or 1) and prepend to result
                binaryResult = (inputNumber % 2) + binaryResult;

                // Update the input number by dividing it by 2
                inputNumber /= 2;
            }

            // Return the final binary result
            return binaryResult;
        }


        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                //binary search to find the minimum in a sorted array
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    //if the middle element >right, minimumwill be to right else minumu is in left half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                //negative numbers cannot be palindromes
                if (x < 0) return false;

                int reversed = 0, original = x;

                //reverse the integer
                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }
                //check if original number is equal to the reversed number
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                //fibonacci(0)=0,fibonacci(1)=1 are the base cases 
                if (n <= 1) return n;

                int a = 0, b = 1, fib = 0;
                //iterative calculation of fibanocci series
                for (int i = 2; i <= n; i++)
                {
                    fib = a + b;
                    a = b;
                    b = fib;
                }

                return fib;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
