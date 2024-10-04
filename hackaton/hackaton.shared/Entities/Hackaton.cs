using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Hackaton
    {
        public int Id { get; set; }
        [Display(Name = "Nombre hackaton")]
        [MaxLength(70, ErrorMessage = "El nombre maximo puede contener 70 caracteres")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha Final")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Tema hackaton")]
        [MaxLength(70, ErrorMessage = "El tema maximo puede contener 70 caracteres")]
        [Required]
        public string Topic { get; set; }

        [Display(Name = "Organizador hackaton")]
        [MaxLength(70, ErrorMessage = "El organizador maximo puede contener 70 caracteres")]
        [Required]
        public string Organizer { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Reward> Rewards { get; set; }
    }
}
