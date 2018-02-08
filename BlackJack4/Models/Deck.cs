using BlackJack3.Models.Enums;
using BlackJack3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlackJack3
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }
    }

}

