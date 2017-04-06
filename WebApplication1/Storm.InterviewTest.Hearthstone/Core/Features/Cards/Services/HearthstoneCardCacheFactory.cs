using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public abstract class HearthstoneCardCacheFactory : IHearthstoneCardCacheFactory
	{
		private readonly IHearthstoneCardParser _parser;

		protected HearthstoneCardCacheFactory(IHearthstoneCardParser parser)
		{
			_parser = parser;
		}


		public IHearthstoneCardCache Create()
		{
			var cards = PopulateCards(_parser);
            return new HearthstoneCardCache(cards.ToList()); // why does mapper.map bug if not tolist
//            return new HearthstoneCardCache(cards); 
		}

		protected abstract IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser);
	}
}