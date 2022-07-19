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
        }

        private void GeneratePlayerInfo(List<Player> players) {
            int i = 0;
            foreach(Player player in players) {
                playerInfoUIs.Add(Instantiate(playerInfoPrefab, transform).GetComponent<PlayerInfoUI>());
                playerInfoUIs[i].Set(player);
                i++;
            }
        }
    }
}
