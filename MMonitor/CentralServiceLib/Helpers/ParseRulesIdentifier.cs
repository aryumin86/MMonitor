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
        /// Identifing the rules of parsing of the source.
        /// </summary>
        /// <param name="source"></param>
        public override void Identify(ref TheSource source)
        {
            if(source.TheSourceType == MMonitorLib.Enums.TheSourceType.MASS_MEDIA)
            {
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

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
