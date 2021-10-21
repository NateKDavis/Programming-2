using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class BlackjackGame
    {
        BlackJackHand _dealer;
        BlackJackHand _player;
        Deck _deck;

        public void PlayRound()
        {
            Console.Clear();

            _dealer = new BlackJackHand(true);
            _player = new BlackJackHand(false);
            _deck = new Deck();
            _deck.Shuffle();

            DealInitialCards();

            if (_player.Score != 21 || _dealer.Score != 21)
            {
                PlayersTurn();
                DealersTurn();
            }
            
            DeclareWinner();
        }

        public void DealInitialCards()
        {
            _player.AddCard(_deck.Deal());
            _dealer.AddCard(_deck.Deal());
            _player.AddCard(_deck.Deal());
            _dealer.AddCard(_deck.Deal());
        }

        public void PlayersTurn()
        {
            int userInput;
            string dealerTitle = "-=-=-=-=- Dealer -=-=-=-=-";
            string playerTitle = "-=-=-=-=- Player -=-=-=-=-";

            while (_player.Score < 21)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth / 2) - (dealerTitle.Length / 2), 0);
                Console.WriteLine($"{dealerTitle}");
                Console.SetCursorPosition((Console.WindowWidth / 2) - (7 * _dealer.numOfCards + 7) / 2, Console.CursorTop + 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("       ");
                Console.ResetColor();
                _dealer.Draw(Console.CursorLeft, Console.CursorTop);

                Console.SetCursorPosition((Console.WindowWidth / 2) - 13, Console.CursorTop);
                Console.WriteLine($"{playerTitle}");
                Console.SetCursorPosition((Console.WindowWidth / 2) - (7 * _player.numOfCards + 6) / 2, Console.CursorTop + 1);
                _player.Draw(Console.CursorLeft, Console.CursorTop);

                Console.SetCursorPosition((Console.WindowWidth / 2) - 9, Console.CursorTop + 1);
                userInput = Misc.ReadInteger("1. Hit or 2. Stand: ", 1, 2);

                if (userInput == 1)
                {
                    _player.AddCard(_deck.Deal());
                }
                else
                {
                    break;
                }
            }
        }

        public void DealersTurn()
        {
            while (_dealer.Score < 17)
            {
                _dealer.AddCard(_deck.Deal());
            }       
        }

        public void DeclareWinner()
        {
            string scores = $"Your score: {_player.Score}. Dealer's score: {_dealer.Score}.";
            string msg = "";
            Console.Clear();            

            if (_player.Score > 21)
            {                
                msg = "Dealer Wins. Press any key to continue..";
            }
            else if (_dealer.Score > 21)
            {
                msg = "Player Wins! Press any key to continue..";
            }
            else if (_player.Score == _dealer.Score)
            {
                msg = "Tie. Press any key to continue..";
            }
            else if (_player.Score > _dealer.Score)
            {
                msg = "Player Wins! Press any key to continue..";
            }
            else
            {
                msg = "Dealer Wins. Press any key to continue..";
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - scores.Length / 2, Console.WindowHeight / 2);
            Console.Write(scores);
            Console.SetCursorPosition(Console.WindowWidth / 2 - scores.Length / 2, Console.WindowHeight / 2 + 1);
            Console.Write(msg);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
