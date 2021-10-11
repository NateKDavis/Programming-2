using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackLibrary.ICard;

namespace BlackjackLibrary
{
    public class Hand
    {
        protected List<ICard> _cards = new List<ICard>();

        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public virtual void Draw(int x, int y)
        {
            foreach (ICard item in _cards)
            {
                Draw(Console.CursorTop, Console.CursorLeft + 5);
            }
        }
    }
}
