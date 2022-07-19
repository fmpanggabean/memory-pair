using System;
using System.Collections;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class GameManager : MonoBehaviour {
        public InputManager InputManager => FindObjectOfType<InputManager>();
        public CardManager CardManager => FindObjectOfType<CardManager>();
        public PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();
        public CardComparator CardComparator;

        public bool isPlaying;

        public event Action<Player> OnGameOver;

        private void Awake() {
            isPlaying = false;
        }

        private void Start() {
            CardComparator = new CardComparator(InputManager, PlayerManager, CardManager);
            CardManager.OnAllCardsOpened += GameOver;
            PlayerManager.CreatePlayer();
            StartGame();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                StartCoroutine( CardManager.OpenAllCard(CardComparator) );
            }
        }

        private void StartGame() {
            isPlaying = true;
            PlayerManager.NextPlayer();
            InputManager.EnableInteraction();
        }

        private void GameOver() {
            OnGameOver?.Invoke(PlayerManager.GetWinner());
        }
    }
}