using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
    public class HearthstoneCardCacheUpdater : IHearthstoneCardCacheFactory
    {
        private readonly IEnumerable<ICard> _Cards;

        public IHearthstoneCardCache Create()
        {
            return new HearthstoneCardCache(_Cards );
        }

        public HearthstoneCardCacheUpdater(IEnumerable<ICard> cards)
        {
            _Cards = cards;
        }


    }
}