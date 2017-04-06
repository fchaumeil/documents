using System.ComponentModel.DataAnnotations;
namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public enum RarityTypeOptions
	{        
        [Display(Name = "Free")]
        Free,
        [Display(Name = "Common")]
        Common,
        [Display(Name = "Rare")]
        Rare,
        [Display(Name = "Epic")]
        Epic,
        [Display(Name = "Legendary")]
		Legendary
	}
}