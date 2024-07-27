namespace IBERDROLA.TechnicalTest.ExternalServices.Character.Response
{
    public class InfoRS
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string? next { get; set; }
        public object? prev { get; set; }
    }
}
