using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
    public class MediaProvider
    {
        private const string mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";

        public void getCardImageToCache(string idCard, string localFile)
        {
            if (!System.IO.File.Exists(localFile))
            {
                string url = string.Format(mediaSourceUrl, idCard);
                Directory.CreateDirectory(Path.GetDirectoryName(localFile));
                var client = new WebClient();
                client.DownloadFile(url, localFile);
            }
        }

    }
}