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
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://" + source.Url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(source.Enc)))
                {
                    responseString = stream.ReadToEnd();
                }
                
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(responseString);

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

                foreach(var l in linkedPages.Union(linkedPages2).Union(linkedPages3))
                {
                    if ((l.Trim('/').EndsWith("feed") || l.Contains("rss")) && !l.Contains("comment"))
                    {
                        string resL = string.Empty;
                        if (!l.Contains("http"))
                            resL = "http://" + l;
                        else
                            resL = l;

                        rssLinks.Add(resL);
                    }  
                }

                source.RssPages = new List<RssPage>();
                foreach(var l in rssLinks)
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
    }
}
