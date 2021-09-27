using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{

    public class Deck
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
        public List<Card> cards { get; set; }
    }
    public class Card
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }

    }
}
