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
                    //documents loaded from rss
                    var docs = new List<HtmlDocument>();
                    var xPathes = new List<string>();
                    var urls = new List<string>();
                    var pages = new List<HtmlDocument>();

                    //getting links from rss feeds
                    foreach (var rssLink in source.RssPages)
                    {
                        var doc = new HtmlDocument();
                        docs.Add(doc);
                        OpenUrlAndLoadHtml(doc, rssLink.Url, source);

                        urls = GetDocUrlsWithinSourceDomain(doc, source);
                        if (urls.Count < 10)
                            return;

                        //docs loaded from links at rss page                        
                        foreach(var u in urls)
                        {
                            try
                            {
                                HtmlDocument page = new HtmlDocument();
                                pages.Add(page);
                                OpenUrlAndLoadHtml(page, u, source);
                                xPathes.Add(GetLongestTextContainerIdentifier(page));
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }

                    //identifing the most occured xpath
                    if(xPathes.Count >= 10)
                    {
                        source.PageParsingRules.Add(new PageParsingRule()
                        {
                            ContentXPath = xPathes.GroupBy(x => x)
                                .Select(group => new
                                {
                                    XPa = group.Key,
                                    Cou = group.Count()
                                })
                                .OrderByDescending(x => x.Cou)
                                .First()
                                .XPa
                        }); 
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

        /// <summary>
        /// Get all urls of html page.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private List<string> GetDocUrlsWithinSourceDomain(HtmlDocument doc, TheSource source)
        {
            var res = new List<string>();
            res.AddRange(doc.DocumentNode.SelectNodes("//a[@href]")
                .Select(n => n.GetAttributeValue("href", string.Empty)));

            res = res.Where(u => Uri.IsWellFormedUriString(u, UriKind.Relative) || u.Contains(source.Url)).ToList();

            return res;
        }

        /// <summary>
        /// Get div or span with longest text within it.
        /// p and br tags are excluded from text.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private string GetLongestTextContainerIdentifier(HtmlDocument doc)
        {
            string res = string.Empty;

            return res;
        }
    }
}
