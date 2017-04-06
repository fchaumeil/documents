using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
    public interface IPathProvider
    {
        string MapPath(string path);
    }
}
