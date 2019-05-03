using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;

		public SearchCardsQuery(string q)
		{
            _q = q ?? string.Empty ;
		}

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        {
            IEnumerable<ICard> queryEnumarable = queryOver.AsEnumerable<ICard>();
            IEnumerable<ICard> result = queryEnumarable.Where(
                    x => x.Name.IndexOf(_q, StringComparison.OrdinalIgnoreCase) >= 0   ||
                    string.Equals(x.Type.ToString(), _q, StringComparison.OrdinalIgnoreCase) || 
                    string.Equals(x.PlayerClass, _q, StringComparison.OrdinalIgnoreCase)
            );
            
            return result;
        }


	}
}