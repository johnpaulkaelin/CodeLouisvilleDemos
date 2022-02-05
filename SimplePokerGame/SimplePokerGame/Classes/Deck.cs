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

        public Hand Deal(byte numberOfCards)
        {
            if (cards.Count < numberOfCards) throw new ApplicationException("Not enough cards for requested Deal");

            Hand hand = new Hand();

            for(byte i = 0; i < numberOfCards; i++)
            {
                hand.Add(cards[0]);
                cards.RemoveAt(0);
            }

            return hand;
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
