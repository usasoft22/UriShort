using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerApp
{
    public interface IUriHelper
    {
        string GetShortURI(string url);
    }
}
