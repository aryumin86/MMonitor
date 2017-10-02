using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentralServiceLib.Entities
{
    /// <summary>
    /// Search engine.
    /// </summary>
    public class SearchEngine
    {
        private static object _obj = new object();

        public SearchEngine(string baseSearchAddress, int pause, string snippetPageUrlXpath, string snippetTextXpath)
        {
            this._baseSearchAddress = baseSearchAddress;
            this._snippetPageUrlXpath = snippetPageUrlXpath;
            this._snippetTextXpath = snippetTextXpath;
        }

        /// <summary>
        /// This string contains the {0} part that should be replaced with
        /// the search query and {1} should be replaced with param for number of
        /// results on singe page (e.g &num=100
        /// </summary>
        private string _baseSearchAddress { get; set; }

        /// <summary>
        /// Xpath of url of page with snippet text.
        /// </summary>
        private string _snippetPageUrlXpath { get; set; }

        /// <summary>
        /// Xpath of snippet (text fragment found).
        /// </summary>
        private string _snippetTextXpath { get; set; }

        /// <summary>
        /// Pauses between search requests.
        /// </summary>
        private int _pause { get; set; }

        /// <summary>
        /// Minimum of results all the search requests should return totally.
        /// All the urls shold be unique.
        /// </summary>
        private int _minResultsNumOfSearchRequests { get; set; }

        /// <summary>
        /// Make search. Should be locked for 1 thread.
        /// </summary>
        /// <param name="maxSearchResultPagesToGet">How many pages of search results should be retrieved</param>
        /// <param name="source"></param>
        /// <param name="q">search query</param>
        /// <returns></returns>
        public SearchEngineSearchResults MakeSearch(TheSource source, string[] queries, string numOfResultsPart)
        {
            lock(_obj)
            {
                List<string> searchStrings = new List<string>();
                SearchEngineSearchResults results = new SearchEngineSearchResults();

                for (int i = 0; i < queries.Count(); i++)
                {
                    searchStrings.Add(string.Format(this._baseSearchAddress, queries[i]) + numOfResultsPart);
                }

                //if there are no results for query we try others. If there are no results at all
                //it could be ban of search engine or bad queries.
                //so, we make big pause...
                //If there are results - (enough according to _minResultsNumOfSearchRequests parameter)
                //we stop searching and begin opening and analizing of the pages at the sources websites.
                foreach (var q in searchStrings)
                {
                    Thread.Sleep(_pause);

                    //open page with search results
 


                    //parsing for snippets and urls

                    

                    //checking if there are enough results is collected
                    if (results.snippets.Count() >= this._minResultsNumOfSearchRequests)
                        break;
                }
            }

            return null;
        }
    }
}
