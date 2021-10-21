using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class BlackJackHand : Hand
    {
        public int Score { get; private set; }
        public int numOfCards { get; set; }
        public bool IsDealer {get; set; }

        public BlackJackHand(bool isDealer)
        {
            IsDealer = isDealer;
        }

        public override void AddCard(ICard card)
        {
            _cards.Add((BlackjackCard)card);
            numOfCards++;
            Score = 0;

            foreach (BlackjackCard item in _cards)
            {
                if (card.Face == Blackjack.CardFace.A)
                {
                    if (Score > 10 )
                    {
                        Score = Score + 1;
                    }
                    else
                    {
                        Score = Score + item.Value;
                    }
                }
                else
                {
                    Score = Score + item.Value;
                }                
            }
        }

        public override void Draw(int x, int y)
        {
            if (IsDealer == true)
            {
                _cards[1].Draw(x + 5, y);
                Console.SetCursorPosition((Console.WindowWidth / 2) - 4, Console.CursorTop + 1);
            }
            else
            {
                base.Draw(x, y);
                Console.SetCursorPosition((Console.WindowWidth / 2) - 4, Console.CursorTop + 1);
                Console.WriteLine($"Score: {Score}\n");
            }
        }
    }
}
