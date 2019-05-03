namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public class SpellCard : Card, ISpellCard
	{
		public SpellCard(string id) : base(id, CardTypeOptions.Spell)
		{
		}
	}
}