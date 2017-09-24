using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLib.Entities
{
    /// <summary>
    /// Not just a snippet, but also a url of page containing 
    /// the snippet (publication text part).
    /// </summary>
    public class SearchEngineSnippet
    {
        /// <summary>
        /// Url of search result.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Text of snippet
        /// </summary>
        public string Content { get; set; }
    }
}
