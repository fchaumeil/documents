using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class FindPlayableHeroCardsQuery : CardListLinqQueryObject<HeroCard>
	{
        public override IEnumerable<HeroCard> Execute(IHearthstoneCardCache cache)
        {
            IEnumerable<HeroCard> result = ExecuteLinq(cache.FindAll<HeroCard>().AsQueryable());
            List<HeroCard> resultList = result.ToList<HeroCard>();
            return resultList;
        }

		protected override IEnumerable<HeroCard> ExecuteLinq(IQueryable<HeroCard> queryOver)
		{
			return queryOver.Where(x => x.Id.StartsWith("HERO"));
		}
	}
}