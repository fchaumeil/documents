using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class FilterHeroCardsQuery: CardListLinqQueryObject<ICard>
	{
        private readonly string _type;
        

        public FilterHeroCardsQuery(string type)
		{
            _type = type ?? string.Empty;
		}


        public override IEnumerable<ICard> Execute(IHearthstoneCardCache cache)
        {
            IEnumerable<ICard> result = ExecuteLinq(cache.FindAll<ICard>().AsQueryable());
            List<ICard> resultList = result.ToList<ICard>();
            return resultList;
        }

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        {
            IEnumerable<ICard> queryEnumarable = queryOver.AsEnumerable<ICard>();//.Where(x => x.Id.StartsWith("HERO"))
            IEnumerable<ICard> result = queryEnumarable.Where(x=>
                    string.Equals(x.Type.ToString(), _type, StringComparison.OrdinalIgnoreCase));
            
            return result;
        }


	}
}
   