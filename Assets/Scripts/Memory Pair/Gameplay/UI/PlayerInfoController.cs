using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay
{
    public class PlayerInfoController : MonoBehaviour
    {
        public PlayerManager PlayerManager => FindObjectOfType<PlayerManager>();

        public GameObject playerInfoPrefab;
        public List<PlayerInfoUI> playerInfoUIs;

        private void Awake() {
            PlayerManager.OnPlayerCreated += GeneratePlayerInfo;
            PlayerManager.OnNextPlayer += ShowActivePlayer;

        }

        private void PlayerScoreGainEvent(Player player, PlayerInfoUI playerInfoUI) {
            player.OnScoreAdded += playerInfoUI.SetScore;
        }

        private void ShowActivePlayer(int playerIndex) {
            for (int i=0; i<playerInfoUIs.Count; i++) {
                if (i == playerIndex) {
                    playerInfoUIs[i].SetAsActive();
                } else {
                    playerInfoUIs[i].SetAsDeactive();
                }
            }
        }

        private void GeneratePlayerInfo(List<Player> players) {
            Debug.Log("Player info genereted");
            int i = 0;
            foreach(Player player in players) {
                playerInfoUIs.Add(Instantiate(playerInfoPrefab, transform).GetComponent<PlayerInfoUI>());
                playerInfoUIs[i].Set(player);
                PlayerScoreGainEvent(player, playerInfoUIs[i]);
                i++;
            }
        }
    }
}
