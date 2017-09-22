using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Updates of source page (news page).
    /// </summary>
    [Table("NewsPages")]
    public class NewsPage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public TheSource TheSource { get; set; } 
        public int TheSourceId { get; set; }
    }
}
