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
            Console.SetCursorPosition(x, y);
            int idx = 0;
            foreach (ICard item in _cards)
            {
                if (idx % 7 == 0)
                {
                    Console.WriteLine();
                }
                
                item.Draw(x + (12 * idx), y);
                idx++;
            }
        }
    }
}
