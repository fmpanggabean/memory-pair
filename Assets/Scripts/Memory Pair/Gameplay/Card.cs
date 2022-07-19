using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MemoryPair.Gameplay
{
    public class Card : MonoBehaviour
    {
        public GameObject front;
        public GameObject back;
        public int rank;
        public bool isOpen;

        public event Action<Card> OnOpen;
        public event Action<Card> OnClose;

        private void Awake() {
            isOpen = false;
        }

        internal Vector3 GetPosition() {
            return transform.position;
        }

        internal void SetRank(int i) {
            rank = i;
        }

        internal void SetPosition(Vector3 position) {
            transform.position = position;
        }

        public void Interact(Card card) {
            if (card != this) {
                return;
            }
            if (!isOpen) {
                Open();
            }
        }

        public void Open() {
            back.SetActive(false);
            isOpen = true;
            OnOpen?.Invoke(this);
        }

        public void Close() {
            back.SetActive(true);
            isOpen = false;
            OnClose?.Invoke(this);
        }

        public void SetFrontSprite(Sprite sprite) {
            front.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
