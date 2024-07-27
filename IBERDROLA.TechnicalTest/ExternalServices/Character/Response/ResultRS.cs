namespace IBERDROLA.TechnicalTest.ExternalServices.Character.Response
{
    public class ResultRS
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public string? species { get; set; }
        public string? type { get; set; }
        public string? gender { get; set; }
        public OriginRS? origin { get; set; }
        public LocationRS? location { get; set; }
        public string? image { get; set; }
        public string[]? episode { get; set; }
        public string? url { get; set; }
        public DateTime? created { get; set; }
    }
}
