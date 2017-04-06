using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Card(string id) // called by src="@Model.ImageUrl"
        {
            ServerPathProvider dataPath = new ServerPathProvider();
            var localBaseDirectory = dataPath.MapPath("~/App_Data/media/");
            //C:\\Users\\Administrateur\\Desktop\\WebApplication1\\Storm.InterviewTest.Hearthstone\\App_Data\\media\\

            var cardFilename = string.Format("{0}.png", id);
            string localFile = Path.Combine(localBaseDirectory, cardFilename);

            MediaProvider mediaProvider = new MediaProvider();
            mediaProvider.getCardImageToCache(id, localFile);

            return File(localFile, "image/png");
        }

    }
}