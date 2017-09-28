using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLib.Entities
{
    /// <summary>
    /// Search engine search results.
    /// </summary>
    public class SearchEngineSearchResults
    {
        public List<SearchEngineSnippet> snippets = new List<SearchEngineSnippet>();
    }
}
