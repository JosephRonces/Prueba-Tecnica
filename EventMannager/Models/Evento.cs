using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Evento
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Lugar { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public int UsuarioID { get; set; }
    }
}