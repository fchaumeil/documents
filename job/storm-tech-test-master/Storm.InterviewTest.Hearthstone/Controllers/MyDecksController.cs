using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class MyDecksController : Controller
	{
		public ActionResult Index()
		{
			var searchService = new CardSearchService(MvcApplication.CardCache);
			var heroes = searchService.GetHeroes();
			return View(heroes);
		}
	}
}