using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Publication cluster.
    /// </summary>
    [Table("Clusters")]
    public class Cluster
    {
        public int Id { get; set; }

        /// <summary>
        /// Publications in cluster.
        /// </summary>
        public ICollection<AbstractPublication> Publications;
    }
}
