using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class SearchHeroesQuery: CardListLinqQueryObject<HeroCard>
	{
		private readonly string _q;

        public SearchHeroesQuery(string q, IHearthstoneCardCache cache)
            : base(cache)
		{
            _q = q ?? string.Empty ;
		}


        public override IEnumerable<HeroCard> Execute()
        {
            IEnumerable<HeroCard> result = ExecuteLinq(_Cache.FindAll<HeroCard>().AsQueryable());
            List<HeroCard> resultList = result.ToList<HeroCard>();
            return resultList;
        }

        protected override IEnumerable<HeroCard> ExecuteLinq(IQueryable<HeroCard> queryOver)
        {
            IEnumerable<HeroCard> queryEnumarable = queryOver.Where(x => x.Id.StartsWith("HERO")).AsEnumerable<HeroCard>();
            IEnumerable<HeroCard> result = queryEnumarable.Where(
                    x => x.Name.IndexOf(_q, StringComparison.OrdinalIgnoreCase) >= 0   ||
                    string.Equals(x.Type.ToString(), _q, StringComparison.OrdinalIgnoreCase) || 
                    string.Equals(x.PlayerClass, _q, StringComparison.OrdinalIgnoreCase)
            );
            
            return result;
        }


	}
}