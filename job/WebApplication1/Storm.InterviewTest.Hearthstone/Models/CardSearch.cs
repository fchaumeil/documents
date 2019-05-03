using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.ComponentModel;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardSearchModel
    {
        public IEnumerable<CardModel> AllCards {get; set;}
        public IEnumerable<string> AllPlayerClasses { get; set; }
        public string SelectedPlayerClass { get; set; }
        public CardList DisplayedCards { get; set; }
        public string SelectedHero { get; set; }
        public string SearchTerm { get; set; }

        public CardSearchModel()
        {
            DisplayedCards = new CardList();
        }

        /*public FilterAndQueryModel FilterAndQuery;
        public AgregatorModel Agregator;*/
    }

    /*
    public class FilterAndQueryModel
    {
    }
    public class AgregatorModel
    {
        public IEnumerable<CardModel> AllCards { get; set; }
        public CardList DisplayedCards { get; set; }
        public string SelectedHero { get; set; }

    }*/
}