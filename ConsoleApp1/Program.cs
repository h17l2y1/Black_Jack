using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card(Card.Ranks.Five, Card.Suits.Diamonds);

            var aaa = card.RankValueHigh;
            var bbb = card.RankValueLow;

            Console.WriteLine("Hello World!");
        }
    }
}
