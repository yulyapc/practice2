using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Nombre equipo")]
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Numero de miembros")]
        [Required]
        public int NumberMembers { get; set; }

        public ICollection<Participant> Participants { get; set; }

        public Hackaton Hackaton { get; set; }

    }
}
