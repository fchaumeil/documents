﻿using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models
{
	public class CardModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string PlayerClassText { get; set; }
		public HeroModel PlayerClass { get; set; }

		public string Type { get; set; }
		public int Cost { get; set; }
		public int Attack { get; set; }
		public string Text { get; set; }
		public RarityTypeOptions Rarity { get; set; }
		public string Faction { get; set; }
                
	}
	public class DeckCardModel
	{
		public string Id { get; set; }
        public int count { get; set; }
                
	}
}