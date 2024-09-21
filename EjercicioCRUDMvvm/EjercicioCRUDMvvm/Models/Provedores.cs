using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SQLite;
namespace EjercicioCRUDMvvm.Models
{
    public class Provedores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        public string Empresa { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Encargado { get; set; }


        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo no válido.")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

    }
}
