using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologicos.Modelos
{
    public class Especie
    {
        [Key] public int Codigo {  get; set; }
        public string NombreComun { get; set; }

        //navegacion
        //propiedad que establece la relación entre tablas
        public List<Animal>? Animals { get; set; } 
    }
}
