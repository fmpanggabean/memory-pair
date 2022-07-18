using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryPair.Gameplay
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Sprite[] cardsSprite;

        public List<Card> cardList;

        public void Awake() {
            GenerateCard();
            RandomizeCardPosition();
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
                cardList[i].DisableInteraction();
            }
        }

        private Vector3 GetCardPosition(int i) {
            Vector3 offset = new Vector3(i % 11, i / 11, 0);
            return transform.position + offset;
        }
    }
}
