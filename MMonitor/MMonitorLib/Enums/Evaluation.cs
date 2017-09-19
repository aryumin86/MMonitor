using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Enums
{
    /// <summary>
    /// Оценка чего-либо (например, правила парсинга).
    /// </summary>
    public enum Evaluation
    {
        UNDEFINED = 0,
        VERY_BAD = 1,
        BAD = 2, 
        NORMAL = 3,
        GOOD = 4,
        VERY_GOOD = 5
    }
}
