using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {

        [HttpGet]
        public ActionResult Index(string q)
        {
            var searchService = new CardSearchService(MvcApplication.CardCache);
            CardSearchModel CardSearch = new CardSearchModel();
            CardSearch.Cards = searchService.Search(q);
            CardSearch.AllPlayerClasses = CardSearch.Cards.Select(m => m.PlayerClassText).Distinct();
            CardSearch.AllPlayerClasses = addBlank(CardSearch.AllPlayerClasses);
            return View(CardSearch);
        }

        [HttpPost]
        public ActionResult Index(CardSearchModel CardSearch, string q, string pl)
		{
			var searchService = new CardSearchService(MvcApplication.CardCache);
            if (!string.IsNullOrEmpty(CardSearch.SelectedPlayerClasses))
                CardSearch.Cards = CardSearch.Cards.Where(c => string.Equals(c.PlayerClass.ToString(), CardSearch.SelectedPlayerClasses, StringComparison.OrdinalIgnoreCase));

            CardSearch.Cards = searchService.Search( q);
            CardSearch.AllPlayerClasses = CardSearch.Cards.Select(m => m.PlayerClassText).Distinct();
            CardSearch.AllPlayerClasses = addBlank(CardSearch.AllPlayerClasses);
            return View(CardSearch);
		}

        private IEnumerable<String>  addBlank( IEnumerable<string> Ienum){
            List<string> blankList = new List<string>{""};
            IEnumerable<string> blankEnum= blankList.AsEnumerable<string>();
            IEnumerable<string> blankAdded = blankEnum.Concat(Ienum);;
            return blankAdded;
        }
	}
}