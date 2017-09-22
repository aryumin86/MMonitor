using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Comment to post or article.
    /// </summary>
    [Table("TheComments")]
    public class TheComment : AbstractPublication
    {
        /// <summary>
        /// Full publication or a comment.
        /// </summary>
        public AbstractPublication AbstractPublication { get; set; }
        public long AbstractPublicationId { get; set; }
    }
}
