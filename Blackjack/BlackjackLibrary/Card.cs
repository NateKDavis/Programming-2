using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackLibrary.ICard;

namespace BlackjackLibrary
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public void Draw(int x, int y)
        {
            char suitSymbol = '#';
            string faceToUse = "";
            int faceNum = 0;

            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);

            if((int)Suit == 2 || (int)Suit == 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if((int)Suit == 2)
                {
                    suitSymbol = '♥';
                }
                if ((int)Suit == 4)
                {
                    suitSymbol = '♦';
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if ((int)Suit == 1)
                {
                    suitSymbol = '♠';
                }
                if ((int)Suit == 3)
                {
                    suitSymbol = '♣';
                }
            }

            if(Face == CardFace.A || Face == CardFace.J || Face == CardFace.Q || Face == CardFace.K)
            {
                faceToUse = $"{Face}";
            }
            else
            {
                faceToUse = $"{(int)Face}";
            }

            int.TryParse(faceToUse, out faceNum);
            if (faceNum == 10)
            {
                Console.Write($" {(faceToUse)} {suitSymbol}  ");
            }
            else
            {
                Console.Write($" {(faceToUse)}  {suitSymbol}  ");
            }
            
            Console.ResetColor();
        }

        public Card(CardFace face, CardSuit suit )
        {
            Face = face;
            Suit = suit;
        }
    }
}
