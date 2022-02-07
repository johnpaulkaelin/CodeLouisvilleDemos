using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePokerGame.Classes
{
    public class Deck
    {
        private List<Card> cards { get; set; } = new List<Card>();

        public Deck()
        {
            Reset();
        }

        public void Shuffle()
        {
            Reset();
            cards = cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public List<Hand> Deal(byte numberOfPlayers, byte numberOfCardsEach)
        {
            if (cards.Count < numberOfPlayers * numberOfCardsEach) throw new ApplicationException("Not enough cards for requested Deal");

            List<Hand> deal = new List<Hand>();

            for(byte i = 0; i < numberOfCardsEach; i++)
            {
                for (byte j = 0; j < numberOfPlayers; j++)
                {
                    if (deal.Count < j + 1) deal.Add(new Hand());
                    deal[j].Add(cards[0]);
                    cards.RemoveAt(0);
                }
            }

            return deal;
        }

        private void Reset()
        {
            cards.Clear();

            for (byte value = 2; value <= 10; value++)
            {
                foreach (eSuits suit in Enum.GetValues(typeof(eSuits)))
                {
                    cards.Add(new Card(value.ToString(), suit, value, value, value));
                }
            }

            foreach (eSuits suit in Enum.GetValues(typeof(eSuits)))
            {
                cards.Add(new Card("Jack", suit, 10, 10, 11));
            }

            foreach (eSuits suit in Enum.GetValues(typeof(eSuits)))
            {
                cards.Add(new Card("Queen", suit, 10, 10, 12));
            }

            foreach (eSuits suit in Enum.GetValues(typeof(eSuits)))
            {
                cards.Add(new Card("King", suit, 10, 10, 13));
            }

            foreach (eSuits suit in Enum.GetValues(typeof(eSuits)))
            {
                cards.Add(new Card("Ace", suit, 11, 11, 14));
            }
        }
    }
}
