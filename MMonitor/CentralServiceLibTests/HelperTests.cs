using CentralServiceLib.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLibTests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void All_Rss_Pages_Should_Be_Extracted()
        {
            TheSource s = new TheSource()
            {
                Enc = "utf-8",
                Url = "zonakz.net"
            };

            RSSPagesIdentifier rpi = new RSSPagesIdentifier();

            rpi.Identify(ref s);

            Assert.IsTrue(s.RssPages.Count > 0);
        }
    }
}
