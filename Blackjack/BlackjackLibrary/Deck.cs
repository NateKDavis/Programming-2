using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackLibrary.ICard;

namespace BlackjackLibrary
{
    public class Deck
    {
        List<ICard> _card = new List<ICard>();
        List<ICard> deckHalfOne = new List<ICard>();
        List<ICard> deckHalfTwo = new List<ICard>();

        public Deck()
        {
            makeDeck();
        }

        public ICard Deal()
        {            
            if (_card.Count() == 0)
            {
                makeDeck();
                Shuffle();
            }

            ICard dealtCard = _card.First();
            _card.Remove(_card.First());
            
            return dealtCard;            
        }


        public void Shuffle()
        {
            for (int card = 0; card < 52; card++)
            {
                Random rand = new Random();

                if (rand.Next() %  2 == 1)
                {
                    
                    deckHalfOne.Add(_card[card]);
                }

                else
                {
                    deckHalfTwo.Add(_card[card]);                    
                }                
            }
            _card.Clear();
            _card.AddRange(deckHalfOne);
            _card.AddRange(deckHalfTwo);
            deckHalfOne.Clear();
            deckHalfTwo.Clear();
        }

        public void makeDeck()
        {
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int face = 1; face <= 13; face++)
                {
                    _card.Add(CardFactory.CreateBlackjackCard((CardFace)face, (CardSuit)suit));
                }
            }
        }
    }
}
