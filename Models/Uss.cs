using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmpresa.Models
{
    public class Uss
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Correo electronico.")]
        public string Usuario { get; set; }


        [StringLength(100)]
        public string Pass { get; set; }



        [StringLength(255)]
        public string FechaCreacion { get; set; }
    }
}