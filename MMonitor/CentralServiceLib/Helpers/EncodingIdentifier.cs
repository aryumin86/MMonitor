using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLib.Helpers
{
    /// <summary>
    /// Identifies the encoding of the sourse.
    /// </summary>
    public class EncodingIdentifier : AbstractHelper
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private string _responseString;

        /// <summary>
        /// Identifing encoding of web page.
        /// </summary>
        /// <returns></returns>
        public override void Identify(TheSource theSource)
        {
            throw new NotImplementedException();
        }
    }
}
