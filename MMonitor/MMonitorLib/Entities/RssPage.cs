using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Page with RSS.
    /// </summary>
    [Table("RssPages")]
    public class RssPage
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public TheSource TheSourse { get; set; }
        public int TheSourceId { get; set; }
    }
}
