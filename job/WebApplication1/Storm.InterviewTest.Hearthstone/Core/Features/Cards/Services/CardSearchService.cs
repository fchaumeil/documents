using System.Collections.Generic;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class CardSearchService : ICardSearchService
	{
		private readonly IHearthstoneCardCache _cardCache;

		public CardSearchService(IHearthstoneCardCache cardCache)
		{
			_cardCache = cardCache;
		}

        public IHearthstoneCardCache getCardCache { get { return _cardCache; } }

		public CardModel FindById(string id)
		{
			ICard card = _cardCache.GetById<ICard>(id);
			return Mapper.Map<ICard, CardModel>(card);
		}

        public static CardSearchService NonHeroCardSearchService(IHearthstoneCardCache cardCache)
        {
            FindNonHeroCardsQuery findNonHeroCardsQuery = new FindNonHeroCardsQuery();
            IEnumerable<ICard> nonHeroCards = cardCache.Query(findNonHeroCardsQuery);
            HearthstoneCardCache nonHeroCardCache = new HearthstoneCardCache(nonHeroCards);
            return new CardSearchService(nonHeroCardCache);
        }

        public static CardSearchService CardsFilterService(IHearthstoneCardCache cardCache, string playerClass)
        {
            FilterNonHeroCardsQuery filterNonHerCardsQuery = new FilterNonHeroCardsQuery(playerClass);
            IEnumerable<ICard> nonHeroCards = cardCache.Query(filterNonHerCardsQuery);
            HearthstoneCardCache nonHeroCardCache = new HearthstoneCardCache(nonHeroCards);
            return new CardSearchService(nonHeroCardCache);
        }
        
        public static CardSearchService DeckHeroSearchService(IHearthstoneCardCache cardCache)
        {
            SearchCardsQuery findNonHeroCardsQuery = new SearchCardsQuery("");
            IEnumerable<ICard> nonHeroCards = cardCache.Query(findNonHeroCardsQuery);
            HearthstoneCardCache nonHeroCardCache = new HearthstoneCardCache(nonHeroCards);
            return new CardSearchService(nonHeroCardCache);
        }

        public static CardSearchService DeckHeroFilterService(IHearthstoneCardCache cardCache, string type)
        {
            FilterHeroCardsQuery filterHeroCardsQuery = new FilterHeroCardsQuery(type);
            IEnumerable<ICard> nonHeroCards = cardCache.Query(filterHeroCardsQuery);
            HearthstoneCardCache nonHeroCardCache = new HearthstoneCardCache(nonHeroCards);
            return new CardSearchService(nonHeroCardCache);
        }

        public static CardSearchService AllowedDeckCardsFilterService(IHearthstoneCardCache cardCache, string selectedHeroClass)
        {
            FilterAllowedDeckCardsQuery filterAllowedDeckCardsQuery = new FilterAllowedDeckCardsQuery(selectedHeroClass);
            IEnumerable<ICard> nonHeroCards = cardCache.Query(filterAllowedDeckCardsQuery);
            HearthstoneCardCache nonHeroCardCache = new HearthstoneCardCache(nonHeroCards);
            return new CardSearchService(nonHeroCardCache);
        }

		public IEnumerable<CardModel> Search(string searchTerm)
		{
            SearchCardsQuery searchCardsQuery = new SearchCardsQuery(searchTerm);
            IEnumerable<ICard> icards = _cardCache.Query(searchCardsQuery);
            //IEnumerable<ICard> icards = _cardCache.Query(new SearchCardsQuery(searchTerm));
            IEnumerable<CardModel> cards =  Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(icards);
            return cards;
		}

        public IEnumerable<ICard> getCardsFromModel( IEnumerable<CardModel> model)
        {
            IEnumerable<ICard> icards = Mapper.Map<IEnumerable<CardModel>, IEnumerable<ICard>>(model);
            return icards;
        }

		public IEnumerable<CardModel> GetHeroes()
        {
            FindPlayableHeroCardsQuery findPlayableHeroCardsQuery = new FindPlayableHeroCardsQuery();//
            IEnumerable<HeroCard> heroes = _cardCache.Query(findPlayableHeroCardsQuery);
			//IEnumerable<HeroCard> heroes = _cardCache.Query(new FindPlayableHeroCardsQuery());
			return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
		}


        public IEnumerable<CardModel> SearchDeckHeroes(string searchTerm)
        {
            IEnumerable<ICard> ICards = _cardCache.Query(new FindDeckCardsQuery(searchTerm));//SearchHeroesQuery(searchTerm));

            /*FindDeckCardsQuery findDeckCardsQuery = new FindDeckCardsQuery(searchTerm, _cardCache);//
            IEnumerable<ICard> ICards = findDeckCardsQuery.Execute();*/
            return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(ICards);
        }
        /*
        public IEnumerable<CardModel> SearchDeckCards(string searchTerm)
        {
            IEnumerable<ICard> heroes = _cardCache.Query(new FindDeckCardsQuery(searchTerm));//
            return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
        }

        public IEnumerable<CardModel> FilterCardsBytype(string type)
        {
            FindDeckCardsQuery findDeckCardsQuery = new FindDeckCardsQuery(type,_cardCache);//
            IEnumerable<ICard> ICards = findDeckCardsQuery.Execute();
            return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(ICards);
        }*/
	}
}
