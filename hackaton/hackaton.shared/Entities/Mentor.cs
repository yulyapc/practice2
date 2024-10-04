using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Mentor
    {
        public int Id { get; set; }

        [Display(Name = "Nombre mentor")]
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Experiencia")]
        [MaxLength(30, ErrorMessage = "La experiencia maximo puede contener 30 caracteres")]
        [Required]
        public string Experience { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
