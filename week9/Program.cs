/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100  
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Using a list to track unique elements.
                List<int> arr = new List<int>();
                int i;
                for (i = 0; i < nums.Length; i++)
                {
                    // If the current element is not already in arr, add it to arr. This ensures uniqueness.
                    if (!arr.Contains(nums[i]))
                    {
                        arr.Add(nums[i]);
                    }
                }

                return arr.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            // Initialize a new list to store the result and a counter for zeros.
            List<int> arr = new List<int>(); int i, c = 0;
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Loop through each element in the input array.
                for (i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, add it to the result list.
                    if (nums[i] != 0)
                    { arr.Add(nums[i]); }
                    else
                    {
                        // If it's a zero, increment the zero counter.
                        c += 1;
                    }
                }
                // After processing non-zero elements, append zeros to the end of the list as many times as the counter indicates.
                arr.AddRange(Enumerable.Repeat(0, c));

                return arr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            // Initialize a list to hold the list of triplets that sum up to zero.
            IList<IList<int>> result = new List<IList<int>>();
            try
            {
                // First, sort the array to facilitate the use of two-pointer technique.
                Array.Sort(nums); // Sort the array

                // Iterate through the array, using each number as a potential first element of a triplet.
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicates
                        continue;
                    //Use two pointers to explore potential second and third elements.
                    int l = i + 1;//left pointer
                    int r = nums.Length - 1;// right pointer

                    while (l < r)
                    {
                        int sum = nums[i] + nums[l] + nums[r];
                        if (sum == 0)
                        {
                            // If the sum is zero, add the triplet to the result.
                            result.Add(new List<int> { nums[i], nums[l], nums[r] });
                            // Move the left pointer forward to avoid duplicates.
                            while (l < r && nums[l] == nums[l + 1])
                                l++;
                            // Move the right pointer backward to avoid duplicates.
                            while (l < r && nums[r] == nums[r - 1])
                                r--;
                            l++;
                            r--;
                        }
                        else if (sum < 0)
                        {
                            // If the sum is less than zero, move the left pointer to increase the sum.
                            l++;
                        }
                        else
                        {
                            // If the sum is more than zero, move the right pointer to decrease the sum.
                            r--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2

        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int c = 0, i, j = 0;
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Iterate through each element in the array.
                for (i = 0; i < nums.Length - 2; i++)
                {
                    // If the current element and next element is 1, increment count.
                    if (nums[i] == 1 && nums[i + 1] == 1)
                    {
                        // If next element is also 1, increment count.
                        if (nums[i + 1] == 1) { c = 3; }
                        else { c = 2; }
                    }
                }

                return c;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            // Initialize variables:
            // di represents the base value (2^i) for the current binary digit.
            // d will accumulate the decimal equivalent of the binary number.
            int di = 1, i = 0, d = 0;
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Continue the loop until the binary number is reduced to 0.
                while (binary > 0)
                {
                    // Extract the least significant digit (either 0 or 1).
                    int j = binary % 10;
                    // Add to the decimal value: multiply the digit by its base value and add to d.
                    d += di * j;
                    // Prepare di for the next binary digit: multiply by 2 (since it's binary base).
                    di *= 2;
                    // Remove the processed digit from binary.
                    binary = binary / 10;

                }
                // Return the calculated decimal value.
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            int i, d = 0, j = nums.Length;
            // Sort the array to ensure that all consecutive differences are positive.
            Array.Sort(nums);
            try
            {
                // If the array has less than two elements, return 0 since there's no gap to calculate.
                if (nums.Length < 2) { return 0; }
                // Iterate through the array, comparing each pair of consecutive elements.
                for (i = 0; i < j - 1; i++)
                {
                    // Calculate the gap between the current element and the next.
                    if (d < (nums[i + 1] - nums[i]))
                    {
                        // Update maxGap if the current gap is larger than any previously found.
                        d = nums[i + 1] - nums[i];

                    }
                }
                // Return the largest gap found.
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array to ensure we can easily check the triangle inequality theorem
                Array.Sort(nums);
                int i, p = 0;
                // Iterate from the end of the sorted array to find the largest possible perimeter.
                for (i = 0; i < nums.Length - 2; i++)
                {
                    // Check if the current triplet satisfies the triangle inequality theorem.
                    if (nums[i + 2] < (nums[i] + nums[i + 1]))
                    {
                        // If so, we've found the largest possible perimeter, return it.
                        p = nums[i] + nums[i + 1] + nums[i + 2];
                    }

                }

                // If no valid triangle can be formed, return 0.
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Initialize the index to store the position of 'part' in 's'.
                int index;
                // Continue looping as long as 'part' is found within 's'.
                while ((index = s.IndexOf(part)) != -1)
                {
                    // If 'part' is found, remove it from 's' starting from its index.
                    s = s.Remove(index, part.Length);
                }
                // Return the modified string after all occurrences of 'part' have been removed.
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

/*

    Self Actulization:

    1.while finding the answer for this problem i learned about the "contains" method which can easily able to check whether the number is already exist or not the previous array
    2.while finding the answer for this problem i learned about the "Enumberable" method which can add n number of digits from end of the list.
    3.while answering this question i finded about accessing the elements from left to right and handiling the out of range error exception 
    4.
    5.for this question my intial thougth was how can we do without bitwise and math.pow so i brushed up basics and devloped the logic using the 1,2,4,8,16,32 with places
    6.for this question i just traversed thourgh the array and calcutated the differene if it's max then overwrite the previous one
    7.used the basic formula the thirdside should less than the sum of other two sides
    8.learned about the inbulit functions indexof which returns index value of the string where the substring is and used the remove to remove the element from the existing did this until it gives -1 which means there is no posibility of the substruing exists in the main string
 
 */