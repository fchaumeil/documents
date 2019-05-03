using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.IO;

namespace Storm.InterviewTest.Hearthstone.Tests.Base
{
    public class PathProvider : IPathProvider 
    {
        public string MapPath(string path)
        {
            //lets create the cache folder where the test app is runing
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
