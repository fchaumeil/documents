using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.ComponentModel;
//using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class DeckBuilder : ICardList
    {
        public IEnumerable<CardModel> Cards { get; set; }

        //public List<DeckCardModel> Deck { get; set; }

        public List<KeyValuePair<string, int>> DeckCards { get; set; }
        public string DeckCardsJSON { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageNum { get; set; }        

        public DeckBuilder()
        {
            PageSize = 10;
            DeckCards = new List<KeyValuePair<string, int>>();
            DeckCardsJSON =  JsonConvert.SerializeObject(DeckCards).ToString();
        }

        public static DeckBuilder getPageItems(CardSearchModel model, int numPage)
        {
            DeckBuilder displayCards = new DeckBuilder();
            displayCards.PageNum = numPage;
            int nbrCards = model.AllCards.Count();
            displayCards.PageCount = (int)Math.Floor((decimal)(nbrCards / displayCards.PageSize)) + 1;
            displayCards.Cards = model.AllCards.Skip(displayCards.PageSize * (numPage - 1)).Take(displayCards.PageSize);
            //KeyValuePair<string, int> DeckCards = new List<KeyValuePair<string, int>>();
            foreach (CardModel card in displayCards.Cards)
                
                displayCards.DeckCards.Add(new KeyValuePair<string, int>(card.Id, 0));
            return displayCards;
        }
    }
}