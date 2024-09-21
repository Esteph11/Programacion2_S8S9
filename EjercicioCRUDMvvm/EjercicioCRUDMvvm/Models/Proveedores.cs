using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMvvm.Models
{
    public class Proveedores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo no válido.")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

    }
}
