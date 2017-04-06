using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
    public class ServerPathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            // Server is a property of the controller, to access it elsewhere use

            HttpServerUtility server = HttpContext.Current.Server;
            return server.MapPath(path);
        }
    }
}