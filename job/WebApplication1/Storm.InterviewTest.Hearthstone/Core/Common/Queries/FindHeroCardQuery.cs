using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class FindHeroCardQuery : SingleCardLinqQueryObject<HeroCard>
	{
		private readonly string _playerClass;        

		public FindHeroCardQuery(string playerClass) 
		{
			_playerClass = playerClass;
		}
		
		protected override HeroCard ExecuteLinq(IQueryable<HeroCard> queryOver)
		{
            HeroCard hero = queryOver.FirstOrDefault(x => x.PlayerClass == _playerClass && x.Id.StartsWith("HERO"));
            return hero;
		}
	}
}