using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

namespace MemoryPair.Gameplay
{
    public class GameOverUI : BaseUI
    {
        public GameManager GameManager => FindObjectOfType<GameManager>();
        public SceneController SceneController => FindObjectOfType<SceneController>();

        public TMP_Text messageText;
        public Button toMainMenuButton;

        private void Awake() {
            GameManager.OnGameOver += ShowWinner;
            toMainMenuButton.onClick.AddListener(SceneController.MainMenu);
        }
        private void Start() {
            Hide();
        }

        public void ShowWinner(Player player) {
            Show();
            messageText.text = "Player "+player.GetPlayerNumber()+" Win!";
        }
    }
}
