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
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberMembers { get; set; }
        [Required]
        public ICollection<Participant> Participants { get; set; }
    }
}
