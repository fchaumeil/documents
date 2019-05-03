using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class FindAllCardsQuery : CardListLinqQueryObject<ICard>
	{
        public override IEnumerable<ICard> Execute(IHearthstoneCardCache cache)
        {
            IEnumerable<ICard> result = ExecuteLinq(cache.FindAll<ICard>().AsQueryable());
            List<ICard> resultList = result.ToList<ICard>();
            return resultList;
        }

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
			return queryOver;
		}
	}
}