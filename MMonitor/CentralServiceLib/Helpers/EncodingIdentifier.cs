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
    /// Identifies the encoding and title of the sourse.
    /// </summary>
    public class EncodingAndTitleIdentifier : AbstractHelper
    {
        /// <summary>
        /// Identifing encoding of web page.
        /// </summary>
        /// <returns></returns>
        public override void Identify(ref TheSource theSource)
        {
            GetTitleAndEncoding(theSource);
            if (theSource.Title != null && theSource.Title.Contains("�"))
                GetTitleAndEncoding2ndWay(theSource);

            if (theSource.Title != null && !theSource.Title.Contains("�"))
                theSource.AutomaticalEncodingUpdateWasSuccess = true;
            else
                theSource.AutomaticalEncodingUpdateWasSuccess = false;

            theSource.LastTimeAutomaticalEncodingUpdateEffort = DateTime.Now;
        }

        private void GetTitleAndEncoding(TheSource so)
        {
            try
            {
                using (WebClient client = new WebClient())
                using (var read = client.OpenRead("http://" + so.Url))
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.Load(read, true);
                    so.Title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
                    so.Enc = doc.Encoding.BodyName;
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        private void GetTitleAndEncoding2ndWay(TheSource so)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://" + so.Url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                string res = string.Empty;

                using (StreamReader stream = new StreamReader(resp.GetResponseStream(), 
                    Encoding.GetEncoding("windows-1251")))
                {
                    res = stream.ReadToEnd();
                }

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(res);
                so.Title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
                so.Enc = doc.Encoding.BodyName;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
