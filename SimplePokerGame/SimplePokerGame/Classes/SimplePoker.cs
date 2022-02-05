using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouUserInputLibrary;

namespace SimplePokerGame.Classes
{
    public class SimplePoker : CodeLouUserInput
    {
        public SimplePoker() : base("The Simple Poker Game")
        {

        }

        public override bool PlayGame()
        {
            Console.WriteLine();

            Deck deck = new Deck();
            deck.Shuffle();
            List<Card> houseHand = deck.Deal(5);
            List<Card> playerHand = deck.Deal(5);

            Console.WriteLine($"House Hand: {string.Join(",",houseHand.OrderBy(c => c.Weight).Select(c => c.ToString()).ToArray())}");

            Console.WriteLine($"Player Hand: {string.Join(",", playerHand.OrderBy(c=> c.Weight).Select(c => c.ToString()).ToArray())}");

            return true;
        }
    }
}
