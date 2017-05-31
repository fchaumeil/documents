using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Models;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class MyDecksController : Controller
	{
		public ActionResult Index()
		{
            CardSearchService searchService = CardSearchService.DeckHeroSearchService(MvcApplication.CardCache);
            CardSearchModel CardSearch = new CardSearchModel();
            CardSearch.AllCards = searchService.SearchDeckHeroes("");
            CardSearch.DisplayedCards = CardList.getPageItems(CardSearch, 1); 
            Session["model"] = CardSearch;
            return View(CardSearch);
		}

        private IEnumerable<String> addBlank(IEnumerable<string> Ienum)
        {
            List<string> blankList = new List<string> { "" };
            IEnumerable<string> blankEnum = blankList.AsEnumerable<string>();
            IEnumerable<string> blankAdded = blankEnum.Concat(Ienum); ;
            return blankAdded;
        }

        [HttpPost]
        public ActionResult ChooseHero(CardSearchModel CardSearch, string q)
        {
            Session["model"] = CardSearch;
            CardSearchService searchService = CardSearchService.DeckHeroSearchService(MvcApplication.CardCache);
            CardSearch.AllCards = searchService.SearchDeckHeroes(q);
            if (!string.IsNullOrEmpty(CardSearch.SelectedHero))
            {
                CardSearchService filterService = CardSearchService.DeckHeroFilterService(searchService.getCardCache, CardSearch.SelectedHero);
                CardSearch.AllCards = filterService.SearchDeckHeroes(q);
            }
            CardSearch.DisplayedCards = CardList.getPageItems(CardSearch, 1);
            return PartialView("_ImageList", CardSearch.DisplayedCards);
        }

        [HttpPost]
        public ActionResult BuildDeck(CardSearchModel CardSearch)
        {
            Session["model"] = CardSearch;
            CardSearchService searchService = CardSearchService.AllowedDeckCardsFilterService(MvcApplication.CardCache, CardSearch.SelectedHero);
            CardSearch.AllCards = searchService.Search("");
            return PartialView("DeckCardList", DeckBuilder.getPageItems(CardSearch, 1));
        }

        [HttpPost]
        public ActionResult ImagesPage(string page)
        {
            int pageNum = int.Parse(page);
            CardList displayCards = CardList.getPageItems((CardSearchModel)Session["model"], pageNum);
            return PartialView("_ImageList", displayCards);
        }

        [HttpPost]
        public ActionResult CardsPage(string page)
        {
            int pageNum = int.Parse(page);
            DeckBuilder displayCards = DeckBuilder.getPageItems((CardSearchModel)Session["model"], pageNum);
            return PartialView("DeckCardList", displayCards);
        }
	}
}