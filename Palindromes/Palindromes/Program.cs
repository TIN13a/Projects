using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("Enter a word/phrase to see if it's a palindrome.");
                string input = Console.ReadLine().ToString();
                Console.WriteLine();
                char[] arrFwd = input.ToCharArray();
                char[] arrBwd = new char[arrFwd.Length];
                Array.Copy(arrFwd, arrBwd, arrFwd.Length);
                Array.Reverse(arrBwd);
                string stringFwd = new string(arrFwd);
                string stringBwd = new string(arrBwd);
                if (stringFwd == stringBwd) {
                    Console.WriteLine("palindrome:\tyes");
                }
                else {
                    Console.WriteLine("palindrome:\tno");
                }
                Console.WriteLine("forward:\t" + stringFwd + "\nbackwards:\t" + stringBwd + "\n-----------------------------------------------------------------------------\n\n");
            }
        }
    }
}
