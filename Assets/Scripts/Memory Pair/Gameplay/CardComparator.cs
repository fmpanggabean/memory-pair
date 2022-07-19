using System;
using System.Collections;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class CardComparator {
        private Card card1, card2;
        private InputManager inputManager;
        private PlayerManager playerManager;
        private CardManager cardManager;

        public event Action OnCompareStart;
        public event Action OnCompareEnd;
        public event Action OnCardMatch;
        public event Action OnCardMismatch;

        public CardComparator(InputManager inputManager, PlayerManager playerManager, CardManager cardManager) {
            this.inputManager = inputManager;
            this.playerManager = playerManager;
            this.cardManager = cardManager;

            OnCardMatch += playerManager.AddScore;
            OnCardMismatch += playerManager.NextPlayer;
            OnCompareStart += inputManager.DisableInteraction;
            OnCompareEnd += inputManager.EnableInteraction;
            OnCompareEnd += cardManager.CardCheck;

            inputManager.OnCardClicked += GiveCardToCompare;
        }

        internal void GiveCardToCompare(Card card) {
            if (card1 == null) {
                card1 = card;
            } else if (card2 == null) {
                card2 = card;
            }
            if (card1 != null & card2 != null) {
                inputManager.StartCoroutine(Compare(card1, card2));
            }
        }

        public IEnumerator Compare(Card card1, Card card2) {
            OnCompareStart?.Invoke();
            yield return new WaitForSeconds(1);
            
            if (card1.rank == card2.rank) {
                Debug.Log("Card Match!");
                OnCardMatch?.Invoke();
            } else {
                Debug.Log("Card Mismatch!");
                CloseCards();
                OnCardMismatch?.Invoke();
            }
            Reset();
            OnCompareEnd?.Invoke();
        }
        private void Reset() {
            card1 = null;
            card2 = null;
        }
        private void CloseCards() {
            card1.Close();
            card2.Close();
        }
    }
}