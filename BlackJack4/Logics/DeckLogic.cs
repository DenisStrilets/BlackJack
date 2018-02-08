using BlackJack3.Models.Enums;
using BlackJack3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack3.Logics
{
    class DeckLogic
    {

        public Deck deck ;
      
        public DeckLogic(Deck deck)
        {
            this.deck = deck;
        }
        
        public void CreateFullDeck()
        {
            foreach (Suit cardSuit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value cardValue in Enum.GetValues(typeof(Value)))
                {
                    this.deck.Cards.Add(new Card(cardSuit, cardValue));
                }
            }
        }

        public void Shuffle()
        {
            List<Card> tmpDeck = new List<Card>();

            Random random = new Random();
            int randomCarIndex = 0;
            int originSize = this.deck.Cards.Count;
            for (int i = 0; i < originSize; i++)
            {
                randomCarIndex = random.Next((this.deck.Cards.Count - 1 - 0) + 1) + 0;
                tmpDeck.Add(this.deck.Cards[randomCarIndex]);

                this.deck.Cards.RemoveAt(randomCarIndex);
            }
            this.deck.Cards = tmpDeck;
        }

        public override String ToString()
        {
            String cardListOutput = " ";

            foreach (Card aCard in this.deck.Cards)
            {
                cardListOutput += "\n" + aCard.suit.ToString() + "-" + aCard.value.ToString() + " (" + aCard.value.GetEnumDescription().ToString() + ")";
            }
            return cardListOutput;
        }

        public void RemoveCard(Deck comingFrom, int i)
        {
            comingFrom.Cards.RemoveAt(i);
        }

        public Card GetCard(Deck comingFrom, int i)
        {
            return comingFrom.Cards[i];
        }

        public void AddCard(Card addCard)
        {
            this.deck.Cards.Add(addCard);
        }

        public void Draw(Deck comingFrom)
        {
            Card card = GetCard(comingFrom, 0);
            this.deck.Cards.Add(card);

            RemoveCard(comingFrom, 0);
        }

        public int DeckSize()
        {
            return this.deck.Cards.Count;
        }

        public void MoveAllToDeck(Deck moveTo)
        {
            this.deck = new Deck();
        }

        public int CardsValue()
        {
            int totalValue = 0;
            foreach (Card card in this.deck.Cards)
            {
                var cardLogic = new CardLogic(card);
                if (cardLogic.GetValue() == Value.ACE)
                {
                    totalValue += 1;
                }

                if (cardLogic.GetValue() == Value.TWO)
                {
                    totalValue += 2;
                }
                if (cardLogic.GetValue() == Value.THREE)
                {
                    totalValue += 3;
                }
                if (cardLogic.GetValue() == Value.FOUR)
                {
                    totalValue += 4;
                }
                if (cardLogic.GetValue() == Value.FIVE)
                {
                    totalValue += 5;
                }
                if (cardLogic.GetValue() == Value.SIX)
                {
                    totalValue += 6;
                }
                if (cardLogic.GetValue() == Value.SEVEN)
                {
                    totalValue += 7;
                }
                if (cardLogic.GetValue() == Value.EIGHT)
                {
                    totalValue += 8;
                }
                if (cardLogic.GetValue() == Value.NINE)
                {
                    totalValue += 9;
                }
                if (cardLogic.GetValue() == Value.TEN)
                {
                    totalValue += 10;
                }
                if (cardLogic.GetValue() == Value.JACK)
                {
                    totalValue += 10;
                }
                if (cardLogic.GetValue() == Value.KING)
                {
                    totalValue += 10;
                }
                if (cardLogic.GetValue() == Value.QUEEN)
                {
                    totalValue += 10;
                }
            }
            return totalValue;
        }
    }
}
