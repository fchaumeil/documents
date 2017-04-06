namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public class HeroCard : MinionCard
	{
		public HeroCard(string id) : base(id, CardTypeOptions.Hero)
		{
			Health = 30;
		}
	}
}