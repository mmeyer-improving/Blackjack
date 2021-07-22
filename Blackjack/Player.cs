using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        public List<KeyValuePair<string, int>> Hand;
        public bool HasAce;
        public int Total;

        public Player(Deck deck)
        {
            Hand = new List<KeyValuePair<string, int>>();
            Hit(deck);
            Hit(deck);
        }

        public void Hit(Deck deck)
        {
            var card = (deck.Draw());
            Hand.Add(card);

            Total += card.Value;

            if (card.Key.Contains("A") && Total > 21)
            {
                Total -= 10;
            }
        }

        public void DisplayHand()
        {
            foreach(var card in Hand)
            {
                Console.Write($" {card.Key}");
            }
            Console.WriteLine($"  -  Total: {Total}");
            Console.WriteLine("----------");
        }

        public void DealerDisplay()
        {
            Console.WriteLine($"Hidden {Hand.ElementAt(1).Key}");
            Console.WriteLine("----------");
        }
    }
}
