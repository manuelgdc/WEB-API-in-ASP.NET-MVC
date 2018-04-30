using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcEquipo
    {
        public int EmpleadoID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Localizacion { get; set; }
    }
}