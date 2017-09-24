using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Country.
    /// </summary>
    [Table("Counrties")]
    public class Country
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
