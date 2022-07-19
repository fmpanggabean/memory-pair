using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace MemoryPair.Menu
{
    public class Counter : MonoBehaviour
    {
        [Header("Components")]
        public Button increaseButton;
        public Button decreaseButton;
        public TMP_Text label;

        [Header("Attributes")]
        public int minValue;
        public int maxValue;
        public int value;

        private void Awake() {
            increaseButton.onClick.AddListener(Increase);
            decreaseButton.onClick.AddListener(Decrease);
        }
        private void Start() {
            if (value < minValue) {
                value = minValue;
            } else if (value > maxValue) {
                value = maxValue;
            }
            RefreshLabel();
        }

        private void Decrease() {
            value = value > minValue ? value - 1 : minValue;
            RefreshLabel();
        }

        private void RefreshLabel() {
            label.text = value.ToString();
        }

        private void Increase() {
            value = value < maxValue ? value + 1 : maxValue;
            RefreshLabel();
        }
    }
}
