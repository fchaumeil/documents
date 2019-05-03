using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class FilterAllowedDeckCardsQuery: CardListLinqQueryObject<ICard>
	{
        private readonly string _selectedHeroClass;

        public FilterAllowedDeckCardsQuery(string selectedHeroClass)
		{
            _selectedHeroClass = selectedHeroClass ?? string.Empty;
		}


        public override IEnumerable<ICard> Execute( IHearthstoneCardCache cache)
        {
            IEnumerable<ICard> result = ExecuteLinq(cache.FindAll<ICard>().AsQueryable());
            List<ICard> resultList = result.ToList<ICard>();
            return resultList;
        }

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        {
            //IEnumerable<ICard> queryEnumarable = queryOver.AsEnumerable<ICard>();//.Where(x => x.Id.StartsWith("HERO"))
            IEnumerable<ICard> result = queryOver.Where(x =>
                        (
                            string.Equals(x.PlayerClass, _selectedHeroClass, StringComparison.OrdinalIgnoreCase)
                            ||
                            string.IsNullOrEmpty(x.PlayerClass)
                        )
                        &&
                        (
                            string.Equals(x.Type.ToString(), "Minion", StringComparison.OrdinalIgnoreCase)
                            ||
                            string.Equals(x.Type.ToString(), "Spell", StringComparison.OrdinalIgnoreCase)
                            ||
                            string.Equals(x.Type.ToString(), "Weapon", StringComparison.OrdinalIgnoreCase)                        
                        )
                    ).AsEnumerable<ICard>();
            
            return result;
        }


	}
}