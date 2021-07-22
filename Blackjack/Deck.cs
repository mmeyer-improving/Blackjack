using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        public List<KeyValuePair<string, int>> Cards { get; set; }
        public Random Random { get; set; }

        public Deck()
        {
            Cards = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("2♠", 2),
                new KeyValuePair<string, int>("2♥", 2),
                new KeyValuePair<string, int>("2♣", 2),
                new KeyValuePair<string, int>("2♦", 2),
                new KeyValuePair<string, int>("3♠", 3),
                new KeyValuePair<string, int>("3♥", 3),
                new KeyValuePair<string, int>("3♣", 3),
                new KeyValuePair<string, int>("3♦", 3),
                new KeyValuePair<string, int>("4♠", 4),
                new KeyValuePair<string, int>("4♥", 4),
                new KeyValuePair<string, int>("4♣", 4),
                new KeyValuePair<string, int>("4♦", 4),
                new KeyValuePair<string, int>("5♠", 5),
                new KeyValuePair<string, int>("5♥", 5),
                new KeyValuePair<string, int>("5♣", 5),
                new KeyValuePair<string, int>("5♦", 5),
                new KeyValuePair<string, int>("6♠", 6),
                new KeyValuePair<string, int>("6♥", 6),
                new KeyValuePair<string, int>("6♣", 6),
                new KeyValuePair<string, int>("6♦", 6),
                new KeyValuePair<string, int>("7♠", 7),
                new KeyValuePair<string, int>("7♥", 7),
                new KeyValuePair<string, int>("7♣", 7),
                new KeyValuePair<string, int>("7♦", 7),
                new KeyValuePair<string, int>("8♠", 8),
                new KeyValuePair<string, int>("8♥", 8),
                new KeyValuePair<string, int>("8♣", 8),
                new KeyValuePair<string, int>("8♦", 8),
                new KeyValuePair<string, int>("9♠", 9),
                new KeyValuePair<string, int>("9♥", 9),
                new KeyValuePair<string, int>("9♣", 9),
                new KeyValuePair<string, int>("9♦", 9),
                new KeyValuePair<string, int>("10♠", 10),
                new KeyValuePair<string, int>("10♥", 10),
                new KeyValuePair<string, int>("10♣", 10),
                new KeyValuePair<string, int>("10♦", 10),
                new KeyValuePair<string, int>("J♠", 10),
                new KeyValuePair<string, int>("J♥", 10),
                new KeyValuePair<string, int>("J♣", 10),
                new KeyValuePair<string, int>("J♦", 10),
                new KeyValuePair<string, int>("Q♠", 10),
                new KeyValuePair<string, int>("Q♥", 10),
                new KeyValuePair<string, int>("Q♣", 10),
                new KeyValuePair<string, int>("Q♦", 10),
                new KeyValuePair<string, int>("K♠", 10),
                new KeyValuePair<string, int>("K♥", 10),
                new KeyValuePair<string, int>("K♣", 10),
                new KeyValuePair<string, int>("K♦", 10),
                new KeyValuePair<string, int>("A♠", 11),
                new KeyValuePair<string, int>("A♥", 11),
                new KeyValuePair<string, int>("A♣", 11),
                new KeyValuePair<string, int>("A♦", 11)
            };

            Random = new Random();
        }

        public KeyValuePair<string, int> Draw()
        {

            var card = Cards.ElementAt(Random.Next(0, Cards.Count - 1));
            Cards.Remove(card);
            return card;
        }
    }
}
