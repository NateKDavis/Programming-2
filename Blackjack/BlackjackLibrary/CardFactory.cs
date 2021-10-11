using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackLibrary.ICard;

namespace BlackjackLibrary
{
    public static class CardFactory
    {
        public static ICard CreateCard(CardFace face, CardSuit suit)
        {
            Card card = new Card(face, suit);

            return card;
        }

        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            BlackjackCard card = new BlackjackCard(face, suit);

            return card;
        }
    }
}
