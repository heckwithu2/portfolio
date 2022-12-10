using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class eventHasUri
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int eventHasUriId {get; set;}
        public int eventId {get; set;}
        public int uriId {get; set;}

    }
}