using Moq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Mapping;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Mapping
{
	[Category("Mapping")]
	public abstract class MappingCardsContext : ContextSpecification
	{
		protected HeroCard _heroCard;
		protected Mock<IHearthstoneCardCache> _cache;

		protected override void SharedContext()
		{
			_heroCard = new HeroCard("H1")
			{
				Name = "My Hero"
			};

			_cache = CreateDependency<IHearthstoneCardCache>();
			_cache.Setup(s => s.Query(It.IsAny<FindHeroCardQuery>())).Returns(_heroCard);

			AutoMapperProfiles.RegisterProfiles(_cache.Object);
		}
	}
}
