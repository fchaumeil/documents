using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Mapping
{
	public class CardsMappingProfile : Profile
	{
		private readonly IHearthstoneCardCache _hearthstoneCardCache;

		public CardsMappingProfile(IHearthstoneCardCache hearthstoneCardCache)
		{
			_hearthstoneCardCache = hearthstoneCardCache;
		}

		protected override void Configure()
		{
			CreateMap<ICard, CardModel>()
				.Include<Card, CardModel>()
				.Include<MinionCard, MinionModel>()
				.Include<WeaponCard, WeaponModel>()
				.Include<SpellCard, SpellModel>()
				.Include<HeroCard, HeroModel>()
				.ForMember(m => m.PlayerClass,
					opt => opt.ResolveUsing(m => _hearthstoneCardCache.Query(new FindHeroCardQuery(m.PlayerClass))))
				.ForMember(m => m.PlayerClassText, opt =>
				{
					opt.NullSubstitute("Neutral");
					opt.MapFrom(m => m.PlayerClass);
				})
				;
			
			CreateMap<Card, CardModel>();
			CreateMap<MinionCard, MinionModel>();
			CreateMap<WeaponCard, WeaponModel>();
			CreateMap<SpellCard, SpellModel>();
			CreateMap<HeroCard, HeroModel>();
		}
	}
}