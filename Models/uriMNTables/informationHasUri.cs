using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class informationHasUri
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int informationHasUriId {get; set;}
        public int informationId {get; set;}
        public int uriId {get; set;}

    }
}