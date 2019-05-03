using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser) : base(parser)
		{
		}


		protected override IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser)
		{
            using (var reader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/cards.json")))
            {
                JObject cardSets = JObject.Parse(reader.ReadToEnd());
                //JToken cards;
                List<string> acceptedCards = new List<string>() { "Basic", "Classic", "Curse of Naxxramas", "Goblins vs Gnomes" };
                foreach (KeyValuePair<string, JToken> cardList in cardSets)
                {
                    string cardsType = cardList.Key;
                    if (acceptedCards.Contains(cardsType))
                    {

                        foreach (var card in cardList.Value)
                        {
                            var parsedCard = parser.Parse(card.ToString());
                            if (parsedCard != null)
                            {
                                if (string.IsNullOrEmpty(parsedCard.PlayerClass)) parsedCard.PlayerClass = "Neutral";
                                yield return parsedCard;
                            }
                        }
                    }
                }
                /*if (cardSets.TryGetValue("Basic", out cards) && cards.Type == JTokenType.Array)
                {
                    foreach (var card in cards)
                    {
                        var parsedCard = parser.Parse(card.ToString());
                        if (parsedCard != null)
                        {
                            yield return parsedCard;
                        }
                    }
                }
                if (cardSets.TryGetValue("Classic", out cards) && cards.Type == JTokenType.Array)
                {
                    foreach (var card in cards)
                    {
                        var parsedCard = parser.Parse(card.ToString());
                        if (parsedCard != null)
                        {
                            yield return parsedCard;
                        }
                    }
                }
                if (cardSets.TryGetValue("Curse of Naxxramas", out cards) && cards.Type == JTokenType.Array)
                {
                    foreach (var card in cards)
                    {
                        var parsedCard = parser.Parse(card.ToString());
                        if (parsedCard != null)
                        {
                            yield return parsedCard;
                        }
                    }
                }
                if (cardSets.TryGetValue("Goblins vs Gnomes", out cards) && cards.Type == JTokenType.Array)
                {
                    foreach (var card in cards)
                    {
                        var parsedCard = parser.Parse(card.ToString());
                        if (parsedCard != null)
                        {
                            yield return parsedCard;
                        }
                    }
                }*/
            }
		}
	}
}