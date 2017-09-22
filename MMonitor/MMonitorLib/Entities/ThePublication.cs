﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMonitorLib.Entities
{
    /// <summary>
    /// Publication in mass or social media (not a comment, full post or article).
    /// </summary>
    [Table("ThePublications")]
    public class ThePublication : AbstractPublication
    {
    }
}
