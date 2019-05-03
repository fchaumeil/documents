using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.Collections.Generic;

namespace Storm.InterviewTest.Hearthstone.Models
{
    public class CardSearchModel
    {
        public IEnumerable<CardModel> Cards {get; set;}
        public IEnumerable<string> AllPlayerClasses { get; set; }


        public string SelectedPlayerClasses { get; set; }
    }
}