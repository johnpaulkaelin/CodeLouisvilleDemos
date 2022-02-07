using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleLibrary;

namespace SimplePokerGame.Classes
{
    public class SimplePoker : CodeLouisvilleAppBase
    {
        public SimplePoker() : base("The Simple Poker Game")
        {

        }

        public override bool PlayGame()
        {
            Console.WriteLine();

            Deck deck = new Deck();
            deck.Shuffle();
            List<Hand> hands = deck.Deal(2,5);

            Console.WriteLine($"House Hand: {string.Join(",",hands[0].OrderBy(c => c.Weight).Select(c => c.ToString()).ToArray())}");

            Console.WriteLine($"Player Hand: {string.Join(",", hands[1].OrderBy(c=> c.Weight).Select(c => c.ToString()).ToArray())}");

            return true;
        }
    }
}
