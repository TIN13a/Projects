using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame {
    class Game {

        private int amountofPlayers;

        private Player[] players;

        public Game() {

        }

        public void Start() {

            InitPlayers();
        }

        private void InitPlayers() {
            Console.WriteLine("Please enter amount of players");
            amountofPlayers = Int32.Parse(Console.ReadLine());

            players = new Player[amountofPlayers-1];
            for (int i = 0; i < amountofPlayers; i++) {
                Console.WriteLine("Please enter name of player "+(i+1));
                Player player = new Player(Console.ReadLine());
                players[i] = player;
                Console.WriteLine("Welcome " + player.);
            }
        }

        private void GameOn() {
            while (true) {

            }
        }
    }
}
