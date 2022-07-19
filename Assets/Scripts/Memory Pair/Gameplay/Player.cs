using System;

namespace MemoryPair.Gameplay {
    public class Player {
        private int index;
        public int Score { get; set; }

        public event Action<int> OnScoreAdded;

        public Player(int index) {
            this.index = index;
            Score = 0;
        }

        internal void AddScore() {
            Score++;
            OnScoreAdded?.Invoke(Score);
        }
    }
}