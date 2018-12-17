using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_Zadania
{
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
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 6, 7, 3, 5, 8, 9, 1 };
            Console.WriteLine("Missing Member: " + missingMember(array, 0));

            Console.ReadLine();
        }

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
    }
}
