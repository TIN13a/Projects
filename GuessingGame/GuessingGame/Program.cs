﻿using System;
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
            int counter = 1;
            
            while (true) {
                try {
                    // 2014-01-21 DSL
                    // If the user enters a single letter (e.g. "a") it counts as number. 
                    //guessDigit = Convert.ToInt32(Console.ReadLine(), 16);
                    guessDigit = Int32.Parse(Console.ReadLine());

                }
                catch (FormatException) {
                    Console.WriteLine("Type in a number you fucking cuntface!");
                    continue;
                }

                if (guessDigit == rndDigit) {
                    Console.WriteLine("Correct.\nYour guess:\t" + guessDigit + "\nrandom Number:\t" + rndDigit + "\nYou had to guess:\t" + counter + "times.");
                    break;
                }
                else if (guessDigit < rndDigit) {
                    Console.WriteLine("the random number is bigger.");
                }
                else if (guessDigit > rndDigit) {
                    Console.WriteLine("the random number is smaller.");
                }
                counter++;
            }
            Console.ReadKey();
        }
    }
}
