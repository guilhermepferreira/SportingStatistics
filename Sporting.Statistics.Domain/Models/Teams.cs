using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.Domain.Models
{
    public class Teams
    {
        public IEnumerable<TeamResult> Times { get; set; }
    }
}
