using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

        public int RolID { get; set; }
    }
}