using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("The program picked a random number between 0 and 100. Guess which one.");
            Random random = new Random();
            int rndDigit = random.Next(0, 101);
            int guessDigit; 
            int counter = 0;
            while (true) {
                try {
                    guessDigit = Convert.ToInt32(Console.ReadLine(), 16);
                }
                catch (FormatException) {
                    Console.WriteLine("Type in a number you fucking cuntface!");
                    continue;
                }
                
                if (guessDigit == rndDigit) {
                    break;
                }
                else if (guessDigit < rndDigit) {
                    Console.WriteLine("the random number is bigger.");
                }
                else if (guessDigit > rndDigit) {
                    Console.WriteLine("the random number is smaller.");
                }
                Console.WriteLine("Wrong.");
                counter++;
            }
            Console.WriteLine("Your last guess was correct. The random number was: " + rndDigit + "\nYou guessed" + counter + "times.");
            Console.ReadKey();
        }
    }
}
