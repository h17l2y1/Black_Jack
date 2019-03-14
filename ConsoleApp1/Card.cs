using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Card
    {
        public enum Suits { Hearts, Clovers, Clubs, Diamonds };
        public enum Ranks { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        public static int HighestRankIndex = 9;

        // this card
        public Ranks Rank { get; set; }
        public Suits Suit { get; set; }

        private static List<Ranks> _rankList;
        private static List<Suits> _suitList;

        public Card(Ranks rankValue, Suits suit)
        {
            Rank = rankValue;
            Suit = suit;
        }

        public static List<Ranks> ListOfRanks
        {
            get
            {
                if (_rankList != null) return _rankList;

                var result = new List<Ranks>();
                var ranks = Enum.GetValues(typeof(Ranks));
                foreach (var rank in ranks)
                    result.Add((Ranks)rank);
                _rankList = result;
                return result;
            }
        }

        public static List<Suits> ListOfSuits
        {
            get
            {
                if (_suitList != null) return _suitList;

                var suits = Enum.GetValues(typeof(Suits));
                var result = new List<Suits>();
                foreach (var suit in suits)
                    result.Add((Suits)suit);
                _suitList = result;
                return result;
            }
        }

        public int RankValueHigh
        {
            get
            {
                switch (Rank)
                {
                    case Ranks.Ace:
                        return 11;

                    case Ranks.King:
                    case Ranks.Queen:
                    case Ranks.Jack:
                    case Ranks.Ten:
                        return 10;

                    default:
                        return (int)Rank;
                }
            }
        }

        public int RankValueLow
        {
            get
            {
                switch (Rank)
                {
                    case Ranks.Ace:
                        return 1;

                    case Ranks.King:
                    case Ranks.Queen:
                    case Ranks.Jack:
                    case Ranks.Ten:
                        return 10;

                    default:
                        return (int)Rank;
                }
            }
        }

        public static string RankText(Ranks rank)
        {
            var rankChars = "  23456789TJQKA".ToCharArray();
            return rankChars[(int)rank].ToString();
        }

        public override string ToString()
        {
            return RankText(Rank) + Suit;
        }

    }
}
