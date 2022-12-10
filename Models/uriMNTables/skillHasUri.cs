using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace portfolioApi.Models
{
    public class uriHasSkill
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int uriHasSkillId {get; set;}
        public int skillId {get; set;}
        public int uriId {get; set;}

    }
}