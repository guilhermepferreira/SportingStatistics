using System;
using System.Collections.Generic;
using System.Text;

namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class LeagueSeasonsDto
    {
        public int Ano { get; set; }

        public DateTimeOffset? Inicio { get; set; }

        public DateTimeOffset? Fim { get; set; }

        public bool Atual { get; set; }
    }
}
