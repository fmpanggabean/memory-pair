using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay
{
    public class PlayerInput : MonoBehaviour
    {
        private bool isInteractible;

        public event Action<Card> OnCardClicked;

        private void Update() {
            if (!isInteractible) {
                return;
            }

            ClickHandler();
        }
        private void ClickHandler() {
            if (!Input.GetMouseButtonDown(0)) {
                return;
            }
            RaycastHit2D hit2d;
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit2d = Physics2D.Raycast(position, Vector3.forward);
            if (hit2d.collider == null) {
                return;
            }
            Card card = hit2d.collider.GetComponent<Card>();
            if (card == null) {
                return;
            }

            OnCardClicked?.Invoke(card);
        }
        public void DisableInteraction() {
            isInteractible = false;
        }
        public void EnableInteraction() {
            isInteractible = true;
        }
    }
}
