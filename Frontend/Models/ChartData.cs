using Common.Application;

namespace Common.Web
{
    public class ChartData : IEntity<string>
    {
        public string Id { get; set; }

        public decimal Data { get; set; }

        public string Color { get; set; }

        public string Label { get; set; }
    }
}
