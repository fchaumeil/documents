using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;
using System;
using System.IO;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    class whenRetrievingMedia : MediaProviderContext
    {
        protected string cardId;
        protected string mediaSourceUrl;
        protected string relativeMediaPath;

        protected override void Context()
        {
            cardId = "EX1_066";
            mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";
            relativeMediaPath = @"App_Data/media/";

            _MediaProvider = new MediaProvider();
            _PathPovider = new PathProvider();
        }

        protected override void Because()
        {
            var localBaseDirectory = _PathPovider.MapPath(relativeMediaPath);
            var cardFilename = string.Format("{0}.png", cardId);
            string localFile = Path.Combine(localBaseDirectory, cardFilename);

            _MediaProvider.getCardImageToCache(cardId, localFile);
        }

        [Test]
        public void ShouldFindCorrespondingMediaInCache()
        {
            string mediaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeMediaPath,cardId+".png");
            File.Exists(mediaPath).ShouldBeTrue();
        }

    }
}
