using System;
using System.Collections.Generic;
using System.ComponentModel;
using FizzWare.NBuilder;
/*using Storm.InterviewTest.Hearthstone.Controllers;
 .Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;*/
using Storm.InterviewTest.Hearthstone.Tests.Specification;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Tests.Base
{
    class MediaProviderContext : ContextSpecification
    {
        protected MediaProvider _MediaProvider;
        protected PathProvider _PathPovider; 
    }
}
