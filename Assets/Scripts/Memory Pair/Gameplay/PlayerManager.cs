using System;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class PlayerManager : MonoBehaviour {
        public DataContainer DataContainer;

        public List<Player> Players;

        public event Action<List<Player>> OnPlayerCreated;
        public event Action<int> OnNextPlayer;

        private int currentPlayer;

        private void Awake() {
            currentPlayer = -1;
        }
        internal void CreatePlayer() {
            Players = new List<Player>();
            for (int i=0; i<DataContainer.playerCount; i++) {
                Players.Add(new Player(i));
            }
            Debug.Log("Player active: " + Players.Count);
            OnPlayerCreated?.Invoke(Players);
        }

        internal void AddScore() {
            GetCurrentPlayer().AddScore();
        }

        internal void NextPlayer() {
            Debug.Log("Next Player");
            currentPlayer++;
            if (currentPlayer >= Players.Count) {
                currentPlayer = 0;
            }
            OnNextPlayer?.Invoke(currentPlayer);
        }

        internal Player GetWinner() {
            Player winner = Players[0];
            for (int i=1; i<Players.Count; i++) {
                if (Players[i].Score > winner.Score) {
                    winner = Players[i];
                }
            }
            return winner;
        }

        private Player GetCurrentPlayer() {
            return Players[currentPlayer];
        }
    }
}