namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public class WeaponCard : Card, IWeaponCard
	{
		public WeaponCard(string id) : base(id, CardTypeOptions.Weapon)
		{
		}

		public int Durability { get; set; }
	}
}