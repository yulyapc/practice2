using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Display(Name = "Nombre proyecto")]
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(70, ErrorMessage = "La descripcion maximo puede contener 70 caracteres")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(30, ErrorMessage = "El status maximo puede contener 30 caracteres")]
        [Required]
        public string Status { get; set; }

        [Display(Name = "Fecha entrega")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Team Team { get; set; }


    }
}
