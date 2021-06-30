using Otc.ComponentModel.DataAnnotations;

namespace Sporting.Statistics.DbAdapter
{
    public class DbAdapterConfiguration
    {
        [Required]
        public string SqlConnectionString { get; set; }
    }
}
