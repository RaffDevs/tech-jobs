using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techjobs_api.Src.Entities
{
    [Table("employment")]
    public class Employment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "title")]
        public string Title { get; set; }

        [Display(Name = "description")]
        public string Description { get; set; }

        [Display(Name = "qtd_positions")]
        public int QtdPositions { get; set; }

        [Display(Name = "requirements")]
        public string Requirements { get; set; }

        [Display(Name = "published_at")]
        public DateTime PublishedAt { get; set; }

        [Display(Name = "company_id")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
