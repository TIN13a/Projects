using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame {
    class Dice {

        private Random randomNumber = new Random();

        public int roll() {
            return randomNumber.Next(1, 7);
        }
    }
}
