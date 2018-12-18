using System;

namespace IBM_Zadania
{
    class Program
    {
        private static Algorithms algorithms = new Algorithms();

        static void Main(string[] args)
        {
            LongestRow();
            Coins();
            ReverseStringExceptA();
            MissingN();
            ArrayShift();
            DuplicateString();
            ReverseString();
            StringMathematic();
            Console.ReadLine();
        }

        private static void LongestRow()
        {
            Console.WriteLine("Longest Lines: ");

            foreach (string line in algorithms.FindLongestLines("a", "b", "c"))
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("-----");

            foreach (string line in algorithms.FindLongestLines("a", "ab", "abc"))
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }

        private static void Coins()
        {
            Console.WriteLine("Coins count needed to pay:");
            Console.WriteLine(string.Format("1021: {0} coins", algorithms.GetCoinsCountNeededToPay(1021)));
            Console.WriteLine();
        }

        private static void ReverseStringExceptA()
        {
            Console.WriteLine("Reverse String Except A:");
            Console.WriteLine(string.Format("Marek: {0}", algorithms.ReverseStringExceptA("Marek")));
            Console.WriteLine(string.Format("Monia: {0}", algorithms.ReverseStringExceptA("Monia")));
            Console.WriteLine();
        }

        private static void MissingN()
        {
            Console.WriteLine("Missing N:");
            Console.WriteLine(string.Format("Missing number in 1,2,3,4,6,7,8,9: {0}", algorithms.FindMissingMember(new int[] { 1, 2, 3, 4, 6, 7, 8, 9 }, 9)));
            Console.WriteLine(string.Format("Missing number in 2,6,7,3,5,8,9,1: {0}", algorithms.FindMissingMember(new int[] { 2, 6, 7, 3, 5, 8, 9, 1 }, 9)));
            Console.WriteLine(string.Format("Missing number in null: {0}", algorithms.FindMissingMember(null, 0)));
            Console.WriteLine(string.Format("Missing number in 1,2,3,4,5,6,7,8: {0}", algorithms.FindMissingMember(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)));
            Console.WriteLine(string.Format("Missing number in 1,2,3,4,5,6,7,10: {0}", algorithms.FindMissingMember(new int[] { 1, 2, 3, 4, 5, 6, 7, 10 }, 9)));
            Console.WriteLine();
        }

        private static void ArrayShift()
        {
            Console.WriteLine("ArrayShift:");

            int[] numbers1 = { 3, 8, 9, 7, 6 };
            int[] numbers2 = { 1, 2, 3, 4 };

            Console.WriteLine("Arrays before shifting: ");

            foreach (int number in numbers1)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            foreach (int number in numbers2)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            algorithms.ShiftArray(ref numbers1, 1);
            algorithms.ShiftArray(ref numbers2, 3);

            Console.WriteLine("Arrays after shifting: ");

            Console.Write("1 Element to right: ");
            foreach (int number in numbers1)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.Write("3 Elements to right: ");
            foreach (int number in numbers2)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static void DuplicateString()
        {
            Console.WriteLine("Find and count duplicate letters:");

            Console.WriteLine("Duplicates in: 'Ala'");
            foreach (var item in algorithms.FindCharacterDuplicates("Ala"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Duplicates in: 'Ala ma kota'");
            foreach (var item in algorithms.FindCharacterDuplicates("Ala ma kota"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Duplicates in: 'International Business Machines'");
            foreach (var item in algorithms.FindCharacterDuplicates("International Business Machines"))
            {
                Console.WriteLine(item);
            }

        }

        private static void ReverseString()
        {
            Console.WriteLine("Reverse a string:");
            Console.WriteLine(string.Format("Kasia: {0}",algorithms.Reverse("Kasia")));
            Console.WriteLine(string.Format("Bielsko-Biala: {0}", algorithms.Reverse("Bielsko-Biala")));
            Console.WriteLine(string.Format("Hello World!: {0}", algorithms.Reverse("Hello World!")));
        }

        private static void StringMathematic()
        {
            Console.WriteLine();
            Console.WriteLine("Calculate artmetic expression from string:");
            Console.WriteLine(string.Format("1 + 2 * 4 === {0}  ---- should be equals: {1}", algorithms.Calculate("1 + 2 * 4"), 9));
            Console.WriteLine(string.Format("2 * (2 + 2 * 2) === {0}  ---- should be equals: {1}", algorithms.Calculate("2 * (2 + 2 * 2)"), 12));
            Console.WriteLine(string.Format("(1 + 3 * 3) / 2 ===  {0}  ---- should be equals: {1}",algorithms.Calculate("(1 + 3 * 3) / 2"), 5));
        }
    }
}
