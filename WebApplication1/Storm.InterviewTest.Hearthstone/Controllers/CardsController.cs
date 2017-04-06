using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Models;
//using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
//using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
//using Storm.InterviewTest.Hearthstone.Core.Common.Queries;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {

        [HttpGet]
        public ActionResult Index(string q)
        {
            CardSearchService searchService = CardSearchService.NonHeroCardSearchService(MvcApplication.CardCache);
            CardSearchModel CardSearch = new CardSearchModel();
            CardSearch.AllCards = searchService.Search(q);
            CardSearch.AllPlayerClasses = CardSearch.AllCards.Select(m => m.PlayerClassText).Distinct();
            CardSearch.AllPlayerClasses = addBlank(CardSearch.AllPlayerClasses);
            CardSearch.DisplayedCards = getPageItems(CardSearch, 1);
            Session["model"] = CardSearch;
            return View(CardSearch);
        }

        [HttpPost]
        public ActionResult CardsPage(string page)
        {
            int pageNum = int.Parse(page) ;
            CardList displayCards = getPageItems((CardSearchModel)Session["model"], pageNum);
            return PartialView("_CardList",displayCards);
        }

        [HttpPost]
        public ActionResult ImagesPage(string page)
        {
            int pageNum = int.Parse(page);
            CardList displayCards = getPageItems((CardSearchModel)Session["model"], pageNum);
            return PartialView("_ImageList", displayCards);
        }

        public CardList getPageItems(CardSearchModel model, int numPage)
        {
            CardList displayCards = new CardList();
            displayCards.PageNum = numPage;
            int nbrCards = model.AllCards.Count();
            displayCards.PageCount = (int)Math.Floor((decimal)(nbrCards / displayCards.PageSize)) + 1;
            displayCards.Cards = model.AllCards.Skip(displayCards.PageSize * (numPage - 1)).Take(displayCards.PageSize);
            return displayCards;
        }

        [HttpPost]
        public ActionResult Index(CardSearchModel CardSearch, string q)
        {
            CardSearchModel model;
            //IEnumerable<ICard> filteredCards;

            if (Session["model"] != null)
            {
                model = (CardSearchModel)Session["model"];
                CardSearch.AllCards = model.AllCards;
                CardSearch.AllPlayerClasses = model.AllPlayerClasses;
                CardSearch.SearchTerm = q;
            }
            CardSearchService searchService = CardSearchService.NonHeroCardSearchService(MvcApplication.CardCache);
            /*switch (CardSearch.SelectedPlayerClass)
            {
                case("all"):
                    CardSearch.SelectedPlayerClass="";
                    break;
                case (""):
                    CardSearch.SelectedPlayerClass = "Neutral";
                    break;
            }*/
            if (!string.IsNullOrEmpty(CardSearch.SelectedPlayerClass))
            {
                if (CardSearch.SelectedPlayerClass!="all")
                    searchService = CardSearchService.CardsFilterService(searchService.getCardCache, CardSearch.SelectedPlayerClass);
            }
            CardSearch.AllCards = searchService.Search(q);
            /*if (!string.IsNullOrEmpty(CardSearch.SelectedPlayerClasse))
            {
                IEnumerable<ICard> cards = searchService.getCardsFromModel(CardSearch.AllCards).AsEnumerable<ICard>();
                filteredCards = cards.Where(c => string.Equals(c.PlayerClass.ToString(), CardSearch.SelectedPlayerClasse, StringComparison.OrdinalIgnoreCase));
                HearthstoneCardCache filteredCardCache = new HearthstoneCardCache(filteredCards);
                searchService = new CardSearchService(filteredCardCache);
            }
            CardSearch.AllCards = searchService.Search(q);*/
            CardSearch.DisplayedCards = getPageItems(CardSearch, 1);
            /*            CardSearch.AllPlayerClasses = CardSearch.Cards.Select(m => m.PlayerClassText).Distinct();
            CardSearch.AllPlayerClasses = addBlank(CardSearch.AllPlayerClasses);*/
            return View(CardSearch);
        }

        private IEnumerable<String>  addBlank( IEnumerable<string> Ienum){
            List<string> blankList = new List<string>{"all"};
            IEnumerable<string> blankEnum= blankList.AsEnumerable<string>();
            IEnumerable<string> blankAdded = blankEnum.Concat(Ienum);;
            return blankAdded;
        }
        
	}
}