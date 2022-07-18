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
        private bool isInteractible;

        public event Action<Card> OnCardClicked;

        private void Update() {
            if (!isInteractible) {
                return;
            }
            if (IsClickedOnCard()) {
                Open();
                OnCardClicked?.Invoke(this);
            }
        }

        private bool IsClickedOnCard() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit2d;
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit2d = Physics2D.Raycast(position, Vector3.forward);
                if (hit2d.collider == null) {
                    return false;
                }
                Card card = hit2d.collider.GetComponent<Card>();
                if (card == null) {
                    return false;
                }
                if (card != this) {
                    return false;
                }
                Debug.Log(this + " is clicked.");
                return true;
            }
            return false;
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

        public void Open() {
            back.SetActive(false);
        }
        public void Close() {
            back.SetActive(true);
        }
        public void SetFrontSprite(Sprite sprite) {
            front.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        public void DisableInteraction() {
            isInteractible = false;
        }
        public void EnableInteraction() {
            isInteractible = true;
        }
    }
}
