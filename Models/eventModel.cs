using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    [Table("event")]
    public class eventModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]        
        public int Id {get; set;}
        public string? title {get; set;}
        public string? description {get; set;}
        public DateTime? startDate {get; set;}
        public DateTime? endDate {get; set;}
    }
}