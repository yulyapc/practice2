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

        [Display(Name = "Descripción premio")]
        [MaxLength(70, ErrorMessage = "La descripción maximo puede contener 100 caracteres")]
        [Required]
        public string Description { get; set; }

        public Hackaton Hackaton { get; set; }
    }
}
