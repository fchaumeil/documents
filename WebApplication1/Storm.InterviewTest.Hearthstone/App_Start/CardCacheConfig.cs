using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone
{
	public class CardCacheConfig
	{
		public static IHearthstoneCardCache BuildCardCacheFromJson()
		{
			var parser = new HearthstoneCardParser();
			var factory = new LocalJsonFeedHearthstoneCardCacheFactory(parser);
			return factory.Create();
		}
	}
}