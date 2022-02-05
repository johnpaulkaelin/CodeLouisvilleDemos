using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePokerGame.Classes
{
    public enum eSuits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public class Card : IComparable<Card>
    {
        public eSuits Suit { get; } 
        public string Name { get; }
        public byte LowValue { get; }
        public byte HighValue { get; }
        public byte Weight { get; }

        public Card(string name, eSuits suit, byte lowValue, byte highValue, byte weight)
        {
            Name = name;
            Suit = suit;
            LowValue = lowValue;
            HighValue = highValue;
            Weight = weight;
        }

        public int CompareTo(Card other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }
    }
}
