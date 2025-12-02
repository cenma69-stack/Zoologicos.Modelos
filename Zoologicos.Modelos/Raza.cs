using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologicos.Modelos
{
    public class Raza
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }

        //Navegacion 
        //propiedad que establece la relación entre tablas
        public List<Animal>? Animals { get; set; }
    }
}
