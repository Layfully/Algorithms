using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IBM_Zadania
{
    public class Algorithms
    {
        /*
         *
         * Longest Row
         *
         * 	Write a Solution which find the line with the maximum
         *  number of word count. In case if it has multiple
         *  lines with the actual maximum number of words,
         *  then return all those lines.
         * 
         */
        public IEnumerable<string> FindLongestLines(params string[] lines)
        {
            int longestLineLength = 0;
            IList<string> longestLines = new List<string>();

            foreach (string line in lines)
            {
                if (line.Length == longestLineLength)
                {
                    longestLines.Add(line);
                }
                else if (line.Length > longestLineLength)
                {
                    longestLineLength = line.Length;
                    longestLines.Clear();
                    longestLines.Add(line);
                }
            }

            return longestLines;
        }

        /*
         *  COINS
         * 
         * 	Write a Solution, which return the minimum number
         *  of coins needed to pay a given amount of money.
         *  we have following available coins:
         *  200, 100, 50, 20, 10, 5, 2, 1.
         */
        public int GetCoinsCountNeededToPay(int payAmount)
        {
            IList<int> availableCoins = new List<int> {200, 100, 50, 20, 10, 5, 2, 1};

            int coinsCount = 0;

            while (payAmount > 0)
            {
                payAmount -= GetLargestPossibleCoin(payAmount, availableCoins);
                coinsCount++;
            }

            return coinsCount;
        }

        private int GetLargestPossibleCoin(int payAmount, IEnumerable<int> coins)
        {
            foreach (var coin in coins)
            {
                if (payAmount >= coin)
                {
                    return coin;
                }
            }

            return 0;
        }

        /*
         * Revert string except "a"
         * 
         * Write a Solution which change order of string
         * but all 'a' have remain in same position.
         * Do not use 'Sort' and use only one loop.
         */
        public string ReverseStringExceptA(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input);
            stringBuilder.Replace("a", string.Empty);
            
            char[] inputWithoutA = new char[stringBuilder.Length];
            stringBuilder.CopyTo(0, inputWithoutA, 0, stringBuilder.Length);
            

            for (int i = 0; i < inputWithoutA.Length + input.Length; i++)
            {
                if (i < inputWithoutA.Length)
                {
                    stringBuilder[i] = inputWithoutA[stringBuilder.Length - 1 - i];
                }
                else if (input[i - inputWithoutA.Length] == 'a')
                {
                    if (i - stringBuilder.Length < inputWithoutA.Length)
                    {
                        stringBuilder.Insert(i - stringBuilder.Length, 'a');
                    }
                    else
                    {
                        stringBuilder.Append('a');
                    }
                }
            }

            return stringBuilder.ToString();
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
        public int FindMissingMember(int[] array, int number)
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
        public void ShiftArray(ref int[] array, int shiftAmount)
        {
            int[] lookupArray = new int[array.Length];
            Array.Copy(array, lookupArray, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                array[(i + shiftAmount) % array.Length] = lookupArray[i];
            }
        }

        /*
         * REVERSE A STRING	Write a Solution which reverse the string word by word.
         * Keep Upper case at the beginning.	INPUT: "Kasia" RESULT: "Aisak"
         * INPUT: "Bielsko-Biala" RESULT: "Alaib-Oksleib"
         * INPUT: "Hello World!" RESULT: "!Dlrow Olleh"
         */
        public string Reverse(string stringToReverse)
        {
            string[] words = stringToReverse.Split(' ');

            StringBuilder stringBuilder = new StringBuilder();

            for(int j = words.Length - 1; j >= 0; j--)
            {
                int lowerAppendIndex = 0;

                //Append every digit/special character before letter
                //Append first encountered letter, convert it to uppercase and break out of loop
                for (int i = words[j].Length - 1; i >= 0; i--)
                {
                    if (char.IsLetter(words[j][i]))
                    {
                        stringBuilder.Append(words[j][i].ToString().ToUpper());
                        lowerAppendIndex = i;
                        break;
                    }
                    else
                    {
                        stringBuilder.Append(words[j][i].ToString());
                    }
                }

                //Convert any other character to lowercase and append it
                for (int i = lowerAppendIndex - 1; i >= 0; i--)
                {
                    stringBuilder.Append(words[j][i].ToString().ToLower());
                }

                //Append space
                stringBuilder.Append(' ');
            }
            return stringBuilder.ToString();
        }

        /*
         * Write a Solution which find and count the duplicate
         * values of an array of string values.	
         * INPUT: "Ala" RESULT: ""
         * INPUT: "Ala ma kota" RESULT: "a-2"
         * INPUT: "International Business Machines" RESULT: "n-4, t-2, e-3, a-3, i-3, s-4"
         */
        public IDictionary<char, int> FindCharacterDuplicates(string input)
        {
            IDictionary<char, int> duplicates = new Dictionary<char, int>();

            for (int  i = 0;  i < input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    continue;
                }

                if (!duplicates.ContainsKey(input[i]))
                {
                    duplicates.Add(input[i], 1);
                }
                else
                {
                    duplicates[input[i]] += 1;
                }
            }

            //Remove all entries which have value of 1.
            foreach (KeyValuePair<char,int> item in duplicates.Where(keyValue => keyValue.Value.Equals(1)).ToList())
            {
                duplicates.Remove(item.Key);
            }

            return duplicates;
        }

        /*
         * String Mathematic	Write a solution to calculate mathematic expression based on string value	
         * Input: "1 + 2 * 4" Output: 9
         * Input: "2 * (2 + 2 * 2)" Output:  12
         * Input: "(1 + 3 * 3) / 2" Output: 5 
         */

        public int Calculate(string expression)
        {
            //DataTable dt = new DataTable();
            //var v = dt.Compute(expression, "");

            return 0;
        }
    }
}
 
 
 