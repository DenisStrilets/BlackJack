using BlackJack3.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack3.Logics
{
    class CardLogic
    {
        public Card card;

        public CardLogic(Card card)
        {
            this.card = card;
        }

        public Value GetValue()
        {
            return this.card.value;
        }

        }
}
