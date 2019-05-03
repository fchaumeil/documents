using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
	public class CardController : Controller
	{
		public ActionResult Details(string id)
		{
			var searchService = new CardSearchService(MvcApplication.CardCache);

			var model = searchService.FindById(id);

			return View(model);
		}
	}
}