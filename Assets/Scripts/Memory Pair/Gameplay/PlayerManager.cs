using System;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class PlayerManager : MonoBehaviour {
        public DataContainer DataContainer;

        private List<Player> Players;

        public event Action<List<Player>> OnPlayerCreated;

        private void Awake() {
            Players = new List<Player>();
        }
        internal void CreatePlayer() {
            for (int i=0; i<DataContainer.playerCount; i++) {
                Players.Add(new Player(i));
            }
            OnPlayerCreated?.Invoke(Players);
        }
    }
}