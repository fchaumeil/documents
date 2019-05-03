using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.ComponentModel;

namespace Storm.InterviewTest.Hearthstone.Models
{
    interface ICardList
    {
        IEnumerable<CardModel> Cards { get; set; }
        int PageSize { get; set; }
        int PageCount { get; set; }
        int PageNum { get; set; }

        //ICardList getPageItems(CardSearchModel model, int numPage);
    }
}
