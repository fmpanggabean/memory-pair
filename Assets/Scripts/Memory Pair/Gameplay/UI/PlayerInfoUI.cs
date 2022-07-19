using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace MemoryPair.Gameplay
{
    public class PlayerInfoUI : MonoBehaviour
    {
        public TMP_Text playerLabel;
        public TMP_Text playerScore;

        public void SetScore(int score) {
            playerScore.text = score.ToString();
        }
        public void SetLabel(string label) {
            playerLabel.text = label;
        }

        internal void Set(Player player) {
            SetLabel("Player " + player.GetPlayerNumber());
            SetScore(0);
        }
    }
}
