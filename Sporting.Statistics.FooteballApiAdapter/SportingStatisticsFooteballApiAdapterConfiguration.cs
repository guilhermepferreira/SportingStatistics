using Otc.ComponentModel.DataAnnotations;

namespace Sporting.Statistics.FooteballApiAdapter
{
    public class SportingStatisticsFooteballApiAdapterConfiguration
    {
        [Required]
        public string FooteballApiUrlBase { get; set; }
        [Required]
        public string RapidApiKey { get; set; }
        [Required]
        public string HostRapidApi { get; set; }
    }
}
