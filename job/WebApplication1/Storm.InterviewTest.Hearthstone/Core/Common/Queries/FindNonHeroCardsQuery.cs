using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class FindNonHeroCardsQuery : CardListLinqQueryObject<Card>
    {
        public override IEnumerable<Card> Execute(IHearthstoneCardCache cache)
        {
            IEnumerable<Card> result = ExecuteLinq(cache.FindAll<Card>().AsQueryable());
            List<Card> resultList = result.ToList<Card>();
            return resultList;
        }

        protected override IEnumerable<Card> ExecuteLinq(IQueryable<Card> queryOver)
        {
            return queryOver.Where(c=>c.Type.ToString()!="Hero" );
        }
    }
}