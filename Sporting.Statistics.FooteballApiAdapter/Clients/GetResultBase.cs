namespace Sporting.Statistics.FooteballApiAdapter.Clients
{
    public class GetResultBase
    {
        public string Get { get; set; }

        public ParametersDto Parameters { get; set; }

        public int Results { get; set; }

        public PagingDto Paging { get; set; }
    }
}
