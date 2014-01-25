using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame {

    class Player {

        private String name;
        private int score = 0;
        private int tempScore = 0;
        private int rolls;

        public Player(String name) {
            this.name = name;
        }

        public void AddToTempScore(int score) {
            tempScore = tempScore + score;
        }

        public int GetTempScore() {
            return tempScore;
        }

        public void DeleteTempScore() {
            tempScore = score;
        }

        public void IncrementRoll() {
            rolls = rolls++;
        }

        public void SaveScore() {
            score = tempScore-5;
        }

        public String GetName() {
            return name;
        }
    }
}
