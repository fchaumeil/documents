using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
	    private const string mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";

        // GET: Media
        public ActionResult Card(string id)
        {
	        var cardFilename = string.Format("{0}.png", id);
	        var localBaseDirectory = Server.MapPath("~/App_Data/media/");
	        Directory.CreateDirectory(localBaseDirectory);
	        var localFile = Path.Combine(localBaseDirectory, cardFilename);
	        if (!System.IO.File.Exists(localFile))
	        {
		        DownloadFromSource(id, localFile);
	        }

			return File(localFile, "image/png");
		}

	    private void DownloadFromSource(string cardId, string localFile) {
		    var client = new WebClient();
			client.DownloadFile(string.Format(mediaSourceUrl, cardId), localFile);
	    }
    }
}