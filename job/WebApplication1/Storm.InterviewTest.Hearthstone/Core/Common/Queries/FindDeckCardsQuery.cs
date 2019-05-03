
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using System;
using System.Collections.Generic;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
    public class FindDeckCardsQuery : CardListLinqQueryObject<ICard>
    {
        private readonly string _searchTerm;
        
        public FindDeckCardsQuery(string searchTerm)
        {
            _searchTerm = searchTerm;
        }

        public override IEnumerable<ICard> Execute(IHearthstoneCardCache cache)
        {
            IEnumerable<ICard> result = ExecuteLinq(cache.FindAll<ICard>().AsQueryable());
            List<ICard> resultList = result.ToList<ICard>();
            return resultList;
        }

        protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
        {
            IEnumerable<ICard> queryEnumarable = queryOver.AsEnumerable<ICard>();
            IEnumerable<ICard> result = queryEnumarable.Where(x =>
                    (
                        string.Equals(x.Type.ToString(), "Minion", StringComparison.OrdinalIgnoreCase)
                        ||
                        string.Equals(x.Type.ToString(), "Spell", StringComparison.OrdinalIgnoreCase)
                        ||
                        string.Equals(x.Type.ToString(), "Weapon", StringComparison.OrdinalIgnoreCase)
                    )
                    &&
                    ( 
                        x.Name.IndexOf(_searchTerm, StringComparison.OrdinalIgnoreCase) >= 0   ||
                        string.Equals(x.Type.ToString(), _searchTerm, StringComparison.OrdinalIgnoreCase) || 
                        string.Equals(x.PlayerClass, _searchTerm, StringComparison.OrdinalIgnoreCase)
                    ) 
            );

            return result;
        }
    }
}
