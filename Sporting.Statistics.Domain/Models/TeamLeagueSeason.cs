using System;

namespace Sporting.Statistics.Domain.Models
{
    public class TeamLeagueSeason
    {
        public Guid Season { get; set; }
        public Guid League { get; set; }
        public Guid Team { get; set; }
    }
}
