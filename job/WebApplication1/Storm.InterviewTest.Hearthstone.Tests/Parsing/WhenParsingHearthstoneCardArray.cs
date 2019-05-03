using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Parsing
{
	[Category("Parsing JSON Feed")]
	public class WhenParsingHearthstoneCardArray : ContextSpecification
    {
	    protected Stream _cardStream;
	    protected IEnumerable<ICard> _cards;
	    protected string _cardsData;

	    protected IHearthstoneCardParser _parser;

	    protected Stream GetCardsDataAsStream()
	    {
			return GetType().Assembly.GetManifestResourceStream("Storm.InterviewTest.Hearthstone.Tests.Base.testcards.json");
	    }

	    protected override void Context()
	    {
		    _cardStream = GetCardsDataAsStream();
			using (var reader = new StreamReader(_cardStream))
			{
				var data = reader.ReadToEnd();
				var jsonData = JArray.Parse(data);
				_cardsData = jsonData.ToString();
			}

			_parser = new HearthstoneCardParser();
		}

	    protected override void Because()
	    {
		    _cards = _parser.ParseArray(_cardsData);
	    }

	    [Test]
	    public void ShouldHaveParsedExpectedCardTypes()
	    {
		    _cards.ShouldNotBeNull();
		    _cards.Count().ShouldEqual(3);
			_cards.OfType<MinionCard>().Count().ShouldEqual(1);
			_cards.OfType<WeaponCard>().Count().ShouldEqual(1);
			_cards.OfType<SpellCard>().Count().ShouldEqual(1);
	    }
    }
}
