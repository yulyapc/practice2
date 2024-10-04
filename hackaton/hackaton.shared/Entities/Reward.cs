using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Reward
    {
        public int Id { get; set; }

        [MaxLength(70, ErrorMessage = "La descripción maximo puede contener 100 caracteres")]
        [Required]
        public string Description { get; set; }

        [Required]
        public Hackaton Hackaton { get; set; }
    }
}
