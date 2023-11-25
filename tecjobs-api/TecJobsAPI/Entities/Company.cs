using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecJobsAPI.Entities
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "about_us")]
        public string AboutUs { get; set; }
        public List<Employment> Employments { get; set; }
    }
}