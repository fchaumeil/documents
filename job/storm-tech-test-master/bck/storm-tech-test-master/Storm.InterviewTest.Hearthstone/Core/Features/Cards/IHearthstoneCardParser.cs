using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public interface IHearthstoneCardParser
	{
		IEnumerable<ICard> ParseArray(string cardsJsonData);
		ICard Parse(string cardsJsonData);
	}
}
