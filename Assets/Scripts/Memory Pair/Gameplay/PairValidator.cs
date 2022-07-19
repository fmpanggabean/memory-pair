using System;
using System.Collections;
using UnityEngine;

namespace MemoryPair.Gameplay {
    public class PairValidator {
        private Card card1;
        private Card card2;

        public event Action OnPair;
        public event Action OnDifferentCard;
        public event Action OnStartValidating;
        public event Action OnFinishedValidating;

        internal void PushCard(Card card, MonoBehaviour monoBehaviour) {
            if (card1 == null) {
                card1 = card;
            }
            else if (card2 == null) {
                card2 = card;
            }

            if (card1 != null && card2 != null) {
                monoBehaviour.StartCoroutine(Validate());
            }
        }

        private IEnumerator Validate() {
            OnStartValidating?.Invoke();

            yield return new WaitForSeconds(1);

            if (card1.rank == card2.rank) {
                OnPair?.Invoke();
            }
            else {
                OnDifferentCard?.Invoke();
                card1.Close();
                card2.Close();
            }
            OnFinishedValidating?.Invoke();
            ResetComparator();
        }
        private void ResetComparator() {
            card1 = null;
            card2 = null;
        }
    }
}