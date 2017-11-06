using HtmlAgilityPack;
using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CentralServiceLib.Helpers
{
    /// <summary>
    /// Identifies RSS pages of the source.
    /// </summary>
    public class RSSPagesIdentifier : AbstractHelper
    {
        public override void Identify(ref TheSource source)
        {
            if (source.Enc == null)
                return;

            try
            {
                HtmlDocument doc = openLinkAndGetDoc("http://" + source.Url, source);
                if (doc == null)
                    return;

                HashSet<string> rssLinks = getRssLinksFromPage(doc, source);

                HashSet<string> temp = new HashSet<string>();
                foreach(var l in rssLinks)
                {
                    HashSet<string> ll = getValidRssPages(l, source);
                    foreach (var x in ll)
                        temp.Add(x);
                }
                rssLinks = temp;

                source.RssPages = new List<RssPage>();
                foreach(var l in rssLinks.Except(source.RssPages.Select(x => x.Url)))
                {
                    source.RssPages.Add(new RssPage()
                    {
                        TheSourceId = source.Id,
                        TheSourse = source,
                        Url = l
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Checks if a page is valid rss page.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private bool IsPageValidRssPage(string url)
        {
            try
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));

                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine(string.Format("RSS Url: {0} . Rss Page validation. Title of rss item: {1}", url, item.Title.Text));
                    break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a page valid rss page and if not
        /// it opens links (calls method) on this page and checks if they are valid rss pages.
        /// If valid - set contanins only 1 valid link from argument.
        /// If can't get links from link (and link is not valid rss page) - returns empty set.
        /// </summary>
        /// <returns></returns>
        private HashSet<string> getValidRssPages(string link, TheSource source)
        {
            HashSet<string> set = new HashSet<string>();

            try
            {
                if (IsPageValidRssPage(link))
                {
                    set.Add(link);
                }
                else
                {
                    HtmlDocument doc = openLinkAndGetDoc(link, source);
                    if (doc == null)
                        return set;
                    var rsslinks = getRssLinksFromPage(doc, source);
                    rsslinks = new HashSet<string>(rsslinks.Select(s => s.Contains("http://") ? s : "http://" + source.Url.Trim('/') + "/" + s.Trim('/')));

                    foreach(var l in rsslinks)
                    {
                        HtmlDocument d = openLinkAndGetDoc(l, source);
                        if (d != null && IsPageValidRssPage(l))
                            set.Add(l);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return set;
        }

        /// <summary>
        /// Gets all rsslinks from html page
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private HashSet<string> getRssLinksFromPage(HtmlDocument doc, TheSource source)
        {
            var linkedPages = doc.DocumentNode.Descendants("a")
                                  .Select(a => a.GetAttributeValue("href", null))
                                  .Where(u => !String.IsNullOrEmpty(u));

            var linkedPages2 = doc.DocumentNode.Descendants("link")
                              .Select(a => a.GetAttributeValue("href", null))
                              .Where(u => !String.IsNullOrEmpty(u));

            var linkedPages3 = doc.DocumentNode.Descendants("link")
                              .Where(a => a.Attributes.Contains("type"))
                              .Where(a => a.Attributes["type"].Value == "application/rss+xml")
                              .Select(a => a.GetAttributeValue("href", null))
                              .Where(u => !String.IsNullOrEmpty(u));

            HashSet<string> rssLinks = new HashSet<string>();

            foreach (var l in linkedPages.Union(linkedPages2).Union(linkedPages3))
            {
                if ((l.Trim('/').EndsWith("feed") || l.Contains("rss")) && !l.Contains("comment"))
                {
                    string resL = string.Empty;
                    if (!l.Contains("http"))
                        rssLinks.Add(l);
                    else
                    {
                        rssLinks.Add(l);
                    }
                }
            }

            return rssLinks;
        }

        private HtmlDocument openLinkAndGetDoc(string link, TheSource source)
        {
            HtmlDocument doc = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(link);
                request.Timeout = source.RequestTimeOut != 0 ? source.RequestTimeOut : 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(source.Enc)))
                {
                    responseString = stream.ReadToEnd();
                }

                doc = new HtmlDocument();
                doc.LoadHtml(responseString);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error with getting HttpResponse and creating HtmlAgilityPach.HtmlDocument for link " + link + Environment.NewLine + ex);
            }

            return doc;
        }
    }
}
