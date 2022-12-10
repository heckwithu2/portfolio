using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class projectHasUri
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int projectHasUriId {get; set;}
        public int projectId {get; set;}
        public int uriId {get; set;}

    }
}