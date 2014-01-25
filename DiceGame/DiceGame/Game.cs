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

            players = new Player[amountofPlayers-1];
            for (int i = 0; i < amountofPlayers; i++) {
                Console.WriteLine("Please enter name of player "+(i+1));
                Player player = new Player(Console.ReadLine());
                players[i] = player;
                Console.WriteLine("Welcome " + player.GetName());
            }
        }

        private void GameOn() {
            Boolean restart = false;
            while (true) {
                foreach (Player player in players) {
                    Console.WriteLine("It's "+player.GetName()+" turn, press enter to roll");
                    Console.ReadLine();
                    int roll = dice.Roll();
                    Console.WriteLine("Your roll is: " + dice.Roll());
                    if(roll == DELETE_ROLL){
                        Console.WriteLine("You lost your score of "+player.GetTempScore());
                        player.DeleteTempScore();
                    } else {
                        player.AddToTempScore(roll);
                        if(IsWinner(player)){
                            Console.WriteLine("You won!!");
                            Console.WriteLine("Press enter for new round...");
                            Console.ReadLine();
                            restart = true;
                            break;
                        } else {
                            Console.WriteLine("Press s to save your score");
                            if( Console.ReadKey().KeyChar == 's'){
                                player.SaveScore();
                            }
                        }
                    }
                }
                if(restart){
                    break;
                }
            }
            if(restart){
                for(int i = 0; i < 4; i++){
                    Console.WriteLine("---");
                }
                Start();
            }
        }

        private Boolean IsWinner(Player player) {
            return player.GetTempScore() >= WIN_SCORE;
        }
    }
}
