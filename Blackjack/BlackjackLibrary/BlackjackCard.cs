using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackLibrary.Card;

namespace BlackjackLibrary
{
    public class BlackjackCard : Card
    {
        public int Value { get; set; }

        public BlackjackCard(CardFace Face, CardSuit Suit) : base(Face, Suit)
        {
            if (Face == CardFace.Ten || Face == CardFace.J || Face == CardFace.Q || Face == CardFace.K)
            {
                Value = 10;
            }
            else if (Face == CardFace.A)
            {
                Value = 11;
            }
            else
            {
                Value = (int)Face;
            }
        }
    }
}
