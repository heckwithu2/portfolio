namespace portfolioApi.Models
{
    public class eventModel
    {
        public int Id {get; set;}
        public string? title {get; set;}
        public string? description {get; set;}
        public DateTime? startDate {get; set;}
        public DateTime? endDate {get; set;}
    }
}