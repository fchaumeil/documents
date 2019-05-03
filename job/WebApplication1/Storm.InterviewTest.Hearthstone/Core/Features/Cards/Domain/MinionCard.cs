namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public class MinionCard : Card, IMinionCard
	{
		public int Health { get; set; }

		public MinionCard(string id)
			: base(id, CardTypeOptions.Minion)
		{
		}

		protected MinionCard(string id, CardTypeOptions type) : base(id, type) { }

	}
}