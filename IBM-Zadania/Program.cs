using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_Zadania
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            ShiftArray(ref array, 1);

            for (int i = 0; i < array.Length; i++)
			{
	            Console.WriteLine("element: " + array[i] );
			}
            Console.ReadLine();
        }


        /*
         * 	Given an array and a number as parameters. The array contains the range of positive integer number from 1 to N
         *  - except one - without duplication in random order. Write a method which returns the missing number after checking  
         *  if the collection is valid for the requirements (returns 0 in invalid cases).
         *  
         * Examples:
         *  list: 1,2,3,4,6,7,8,9 n:9 result:5
         *  list:2,6,7,3,5,8,9,1 n:9 result:4
         *  list:null n:0 result:0
         *  list:1,2,3,4,5,6,7,8 n:8 result:0
         *  list: 1,2,3,4,5,6,7,10 n:9 result:0
        */

        private static int missingMember(int[] array, int number)
        {
            if (array == null || number <= 0)
            {
                return 0;
            }

            HashSet<int> targetSet = new HashSet<int>(Enumerable.Range(1, number).ToArray());
            HashSet<int> inputSet = new HashSet<int>(array);

            int[] missingNumbers = targetSet.Except(inputSet).ToArray();

            return missingNumbers.Length == 1 ? missingNumbers[0] : 0;
        }


        /*
         * Write a Solution which rotate an array element 
         * (shift it) right by one index, and the last element 
         * of the array will be moved to the first place.
         * 
         * INPUT: A= [3, 8, 9, 7, 6] and K = 3, RESULT: [9, 7, 6, 3, 8]
         * INPUT: A= [1, 2, 3, 4] and K = 1, RESULT: [4, 1, 2, 3]
         */
        public static void ShiftArray(ref int[] array, int shiftAmount)
        {
            int[] lookupArray = new int[array.Length];
            Array.Copy(array, lookupArray, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                array[(i + shiftAmount) % array.Length] = lookupArray[i];
            }
        }
    }
}
