using System;
using System.Collections;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class GameManager : MonoBehaviour {
        public InputManager InputManager => FindObjectOfType<InputManager>();
        public CardManager CardManager => FindObjectOfType<CardManager>();
        public PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();

        public bool isPlaying;

        private void Awake() {
            isPlaying = false;

            PlayerManager.CreatePlayer();
        }
        private void Start() {            
            StartGame();
        }

        private void StartGame() {
            isPlaying = true;
            InputManager.EnableInteraction();
        }
    }
}