using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        [Display(Name = "Nombre participante")]
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Rol")]
        [MaxLength(30, ErrorMessage = "El rol maximo puede contener 30 caracteres")]
        [Required]
        public string Rol { get; set; }

        [Display(Name = "Experiencia")]
        [MaxLength(30, ErrorMessage = "La experiencia maximo puede contener 30 caracteres")]
        [Required]
        public string Experience { get; set; }

        public Team Team { get; set; }
    }
}
