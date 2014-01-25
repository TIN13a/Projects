using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame {
    class Game {
        private const int WIN_SCORE = 50;
        private const int DELETE_ROLL = 6;

        private int amountofPlayers;
        private Player[] players;
        private Dice dice;

        public Game() {
            dice = new Dice();
        }

        public void Start() {

            InitPlayers();
            GameOn();
        }

        private void InitPlayers() {
            Console.WriteLine("Please enter amount of players");
            amountofPlayers = Int32.Parse(Console.ReadLine());

            players = new Player[amountofPlayers];
            for (int i = 0; i < amountofPlayers; i++) {
                Console.WriteLine("Please enter name of player "+(i+1));
                Player player = new Player(Console.ReadLine());
                players[i] = player;
                Console.WriteLine("Welcome " + player.GetName());
                Console.WriteLine("");
            }
        }

        private void GameOn() {
            Boolean restart = false;
            while (true) {
                foreach (Player player in players) {
                    restart = Turn(player);
                    if (restart) {
                        break;
                    }
                }
                if(restart){
                    break;
                }
            }
            if(restart){
                ShowNewSite();
                Start();
            }
        }

        private Boolean Turn(Player player) {
            ShowNewSite();

            Console.WriteLine("It's " + player.GetName() + " turn, press enter to roll");
            Console.ReadLine();

            int roll = dice.Roll();
            player.AddToTempScore(roll);
            Console.WriteLine("Your roll is: " + dice.Roll() + " [score: "+player.GetTempScore()+"]");

            if (roll == DELETE_ROLL) {
                Console.WriteLine("You lost your score of " + player.GetTempScore());
                player.DeleteTempScore();
            } else {
                if (IsWinner(player)) {
                    PrintWin();
                    return true;
                } else {
                    Console.Write("Press s to save your score");
                    if (Console.ReadKey().KeyChar == 's') {
                        player.SaveScore();
                        Console.WriteLine("------------- saved.");
                    } else {
                        Console.WriteLine("");
                    }
                }
            }
            return false;
        } 

        private Boolean IsWinner(Player player) {
            return player.GetTempScore() >= WIN_SCORE;
        }

        private void ShowNewSite() {
            for (int i = 0; i < 30; i++) {
                Console.WriteLine("");
            }
        }

        private void PrintWin() {
            Console.WriteLine("You won!!");
            Console.WriteLine("Press enter for new round...");
            Console.ReadLine();
        }
    }
}
