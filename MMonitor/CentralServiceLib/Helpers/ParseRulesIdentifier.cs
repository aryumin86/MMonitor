using HtmlAgilityPack;
using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLib.Helpers
{
    /// <summary>
    /// Identifies the rules of parsing of TheSource.
    /// </summary>
    public class ParseRulesIdentifier : AbstractHelper
    {
        /// <summary>
        /// Identifying the rules of parsing of the source.
        /// </summary>
        /// <param name="source"></param>
        public override void Identify(ref TheSource source)
        {
            if(source.TheSourceType == MMonitorLib.Enums.TheSourceType.MASS_MEDIA)
            {
                List<string> linksToOpen = new List<string>();
                if (source.RssPages == null || source.RssPages.Count == 0)
                {
                    //getting links from main page (not a good idea may be...)

                }
                else
                {
                    //getting links from rss feeds
                    foreach(var rssLink in source.RssPages)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Opens URL page with HttpWebRequest and HtmlAgilityPack.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="Url"></param>
        /// <param name="source"></param>
        private void OpenUrlAndLoadHtml(HtmlDocument doc, string url, TheSource source)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(source.Enc)))
                {
                    responseString = stream.ReadToEnd();
                }
                
                doc.LoadHtml(responseString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
