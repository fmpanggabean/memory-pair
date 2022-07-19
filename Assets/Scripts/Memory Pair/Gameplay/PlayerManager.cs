using System;

using UnityEngine;

namespace MemoryPair.Gameplay {
    public class PlayerManager : MonoBehaviour {
        public DataContainer DataContainer;

        private Player[] Player;

        public event Action<Player[]> OnPlayerCreated;

        internal void CreatePlayer() {
            for (int i=0; i<DataContainer.playerCount; i++) {
                Player[i] = new Player(i);
            }
            OnPlayerCreated?.Invoke(Player);
        }
    }
}