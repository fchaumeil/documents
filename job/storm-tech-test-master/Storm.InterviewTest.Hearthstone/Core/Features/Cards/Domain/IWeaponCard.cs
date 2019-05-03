namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public interface IWeaponCard : ICard
	{
		int Durability { get; set; }
	}
}