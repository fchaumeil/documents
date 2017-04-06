using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Parsing
{
	[Category("Parsing JSON Feed")]
	public class WhenParsingHearthstoneCard : ContextSpecification
	{
		protected Stream _cardStream;
		protected ICard _card;
		protected string _cardData;

		protected IHearthstoneCardParser _parser;

		protected Stream GetCardsDataAsStream()
		{
			return GetType().Assembly.GetManifestResourceStream("Storm.InterviewTest.Hearthstone.Tests.Base.testcard.json");
		}

		protected override void Context()
		{
			_cardStream = GetCardsDataAsStream();
			using (var reader = new StreamReader(_cardStream))
			{
				var data = reader.ReadToEnd();
				var jsonData = JObject.Parse(data);
				_cardData = jsonData.ToString();
			}

			_parser = new HearthstoneCardParser();
		}

		protected override void Because()
		{
			_card = _parser.Parse(_cardData);
		}

		[Test]
		public void ShouldContainExpectedProperties()
		{
			_card.ShouldNotBeNull();
			_card.Id.ShouldEqual("EX1_066");
			_card.ShouldBeOfType(typeof(MinionCard));
		}
	}
}