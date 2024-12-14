using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DataAccess
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nosaukums { get; set; }
        [Required]
        [Range(0, 1000)]
        public int DarbiniekuSK { get; set; }
        [Required]
        [StringLength(50)]
        public string Apraksts { get; set; }
        public List<Employee> Employee { get; } = new();
    }
}
