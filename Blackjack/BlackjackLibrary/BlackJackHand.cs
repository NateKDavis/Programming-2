using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    class BlackJackHand : Hand
    {
        public int Score { get; set; }
        public bool IsDealer {get; set; }

        BlackJackHand(bool isDealer = false)
        {

        }

        public override void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public override void Draw(int x, int y)
        {
            foreach (ICard item in _cards)
            {
                Draw(Console.CursorTop, Console.CursorLeft + 5);
            }
        }
    }
}
