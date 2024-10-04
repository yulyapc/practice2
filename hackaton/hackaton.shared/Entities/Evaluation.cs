using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackaton.shared.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }

        [Display(Name = "Puntuación")]
        [Required]
        public int Score { get; set; }

        [Display(Name = "Observacion y/o Comentarios")]
        [MaxLength(100, ErrorMessage = "EL comentario debe ser menor a 100 caracteres")]
        public string Remarks { get; set; }

        public Project Project { get; set; }

        public Mentor Mentor { get; set; }
    }
}
