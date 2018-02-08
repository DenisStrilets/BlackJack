using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using BlackJack3.Models.Enums;

namespace BlackJack3
{
     public class Card
    {
        public Suit suit;
        public Value value;
        
        public Card(Suit suit, Value value)
        {
            this.value = value;
            this.suit = suit;
        }
        
        public override String ToString()
        {
            return suit.ToString() + "-" + value.ToString() + " (" + value.GetEnumDescription().ToString() + ")";
        }
    }
}
