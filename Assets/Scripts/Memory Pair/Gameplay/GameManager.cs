using System;
using System.Collections;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class GameManager : MonoBehaviour {
        public InputManager inputManager;
        public CardManager cardManager;
        public PlayerManager playerManager;

        public bool isPlaying;

        private void Awake() {
            isPlaying = false;
        }
        private void Start() {
            cardManager.SetClickEvent(inputManager);
            playerManager.SetPlayerCount();
            
            StartGame();
        }

        private void StartGame() {
            isPlaying = true;
            inputManager.EnableInteraction();
        }
    }
}