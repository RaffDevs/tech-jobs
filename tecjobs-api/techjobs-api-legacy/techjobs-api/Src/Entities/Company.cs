using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techjobs_api.Src.Entities
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "employments")]
        public List<Employment> Employments {  get; set; } 
    }
}
