using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Комментарий к посту или статье.
    /// </summary>
    public class TheComment : AbstractPublication
    {
        /// <summary>
        /// Публикация, к которой относится комментарий (может быть и комментарием).
        /// </summary>
        public AbstractPublication Publication { get; set; }
    }
}
