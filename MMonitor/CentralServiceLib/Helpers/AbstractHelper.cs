using MMonitorLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralServiceLib.Helpers
{
    /// <summary>
    /// Identifier different properties of the source.
    /// </summary>
    public abstract class AbstractHelper
    {
        public abstract void Identify(TheSource source);
    }
}
