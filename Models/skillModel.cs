
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class skill
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string? title {get; set;}
        public string? description {get; set;}
    }
}