using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay
{
    public class CardManager : MonoBehaviour
    {
        public InputManager InputManager => FindObjectOfType<InputManager>();

        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Sprite[] cardsSprite;
        
        public List<Card> cardList;

        public event Action OnAllCardsOpened;

        public void Awake() {
            GenerateCard();
            RandomizeCardPosition();
            SetClickEvent();
        }

        private void RandomizeCardPosition() {
            List<Card> randomCardPool = new List<Card>();
            randomCardPool.AddRange(cardList);

            for (int i=0; i<52; i++) {
                int randomCardIndex = UnityEngine.Random.Range(0, randomCardPool.Count);
                SwapCardPosition(cardList[i], randomCardPool[randomCardIndex]);

                randomCardPool.RemoveAt(randomCardIndex);
            }
        }

        internal IEnumerator OpenAllCard(CardComparator cardComparator) {
            foreach (Card card in cardList) {
                if (!card.isOpen) {
                    Card c1 = card;
                    Card c2 = SearchMatch(card);
                    c1.Open();
                    c2.Open();
                    yield return cardComparator.Compare(c1, c2);                    
                }
            }
        }

        private Card SearchMatch(Card card1) {
            foreach (Card card2 in cardList) {
                if (card1 == card2) {
                    continue;
                }
                if (card2.isOpen) {
                    continue;
                }
                if (card1.rank == card2.rank) {
                    return card2;
                }
            }
            return null;
        }

        internal void CardCheck() {
            foreach(Card card in cardList) {
                if (!card.isOpen) {
                    return;
                }
            }
            OnAllCardsOpened?.Invoke();
        }

        internal void SetClickEvent() {
            for (int i=0; i<52; i++) {
                InputManager.OnCardClicked += cardList[i].Interact;
            }
        }

        private void SwapCardPosition(Card card1, Card card2) {
            Vector3 temp;
            temp = card1.GetPosition();
            card1.SetPosition(card2.GetPosition());
            card2.SetPosition(temp);
        }

        private void GenerateCard() {
            for (int i = 0; i < 52; i++) {
                cardList.Add(Instantiate(cardPrefab, transform).GetComponent<Card>());
                cardList[i].SetFrontSprite(cardsSprite[i]);
                cardList[i].SetRank((i % 13) + 1);
                cardList[i].SetPosition(GetCardPosition(i));
            }
        }

        private Vector3 GetCardPosition(int i) {
            Vector3 offset = new Vector3(i % 11, i / 11, 0);
            return transform.position + offset;
        }
    }
}
