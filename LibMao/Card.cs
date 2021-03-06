﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public enum CardValue
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit Suit;
        public CardValue Value;

        public Card(Suit s, CardValue v)
        {
            Suit = s;
            Value = v;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
