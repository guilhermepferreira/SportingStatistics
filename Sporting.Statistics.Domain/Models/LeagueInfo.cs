﻿using System;

namespace Sporting.Statistics.Domain.Models
{
    public class LeagueInfo
    {
        public Guid Identificador { get; set; }

        public int? IdentificadorLiga { get; set; }

        public string Nome { get; set; }

        public LeagueType TipoLiga { get; set; }

        public string Logo { get; set; }
    }
}
