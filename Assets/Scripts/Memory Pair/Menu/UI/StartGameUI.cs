using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MemoryPair.Menu
{
    public class StartGameUI : BaseUI
    {
        public Button StartButton;
        public Counter counter;
        public DataContainer dataContainer;

        public SceneController SceneController => FindObjectOfType<SceneController>();

        private void Awake() {
            StartButton.onClick.AddListener(SetPlayerCount);
            StartButton.onClick.AddListener(SceneController.PlayGame);
        }

        private void SetPlayerCount() {
            dataContainer.playerCount = counter.value;
        }
    }
}
