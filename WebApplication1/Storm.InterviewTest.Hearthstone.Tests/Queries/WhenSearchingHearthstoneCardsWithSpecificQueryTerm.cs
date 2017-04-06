using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;
using System;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
	[Category("Cache")]
	public class WhenSearchingHearthstoneCardsWithSpecificQueryTerm : HearthstoneCardCacheContext
	{
        protected IEnumerable<ICard> _resultName;
        protected IEnumerable<ICard> _resultCase;
        protected IEnumerable<ICard> _resultType;
        protected string queryName;
        protected string queryCase;
        protected string queryType;

		protected override IEnumerable<ICard> Cards()
		{
			return new List<ICard>(base.Cards())
			{
				CreateRandomMinionCardWithId("99", minion =>
				{
					minion.Name = "my Special card";
					minion.Faction = FactionTypeOptions.Alliance;
					minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = "Mage";
				})
			};
		}

		protected override void Context()
		{
			queryName = "special";
            queryCase = "mage";
            queryType = "minion";
		}

		protected override void Because()
		{
            _resultName = _hearthstoneCardCache.Query(new SearchCardsQuery(queryName));
            _resultCase = _hearthstoneCardCache.Query(new SearchCardsQuery(queryCase));
            _resultType = _hearthstoneCardCache.Query(new SearchCardsQuery(queryType));
		}

        [Test]
        public void ShouldReturnExpectedTypeSearchResults()
        {
            IEnumerable<ICard> getResult = _resultType.Where(r => r.Name == "my Special card");
            foreach (ICard card in _resultType)
                Console.WriteLine(card.Name);
            getResult.Count().ShouldEqual(1);
            getResult.First().Type.ToString().ShouldEqual(CardTypeOptions.Minion.ToString());
        }

		[Test]
		public void ShouldReturnExpectedNameSearchResults()
		{
            _resultName.Count().ShouldEqual(1);
            _resultName.First().Name.ShouldEqual("my Special card");
		}

        [Test]
        public void ShouldReturnExpectedCaseSearchResults()
        {
            _resultCase.Count().ShouldEqual(1);
            _resultCase.First().Name.ShouldEqual("my Special card");
            _resultCase.First().PlayerClass.ShouldEqual("Mage");
        }
	}
}