using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class information
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? introduction { get; set; }
    }
}