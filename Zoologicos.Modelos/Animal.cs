using System.ComponentModel.DataAnnotations;

namespace Zoologicos.Modelos
{
    public class Animal
    {
        [Key] public int Id { get; set; }  
        public string Nombres { get; set; }
        public int Edad {  get; set; }
        public string Genero { get; set; }

        //FK - clave foranea
        public int EspeciesCodigo { get; set; }
        public int RazaId {  get; set; }

        //NAVEGACION (opcional)
        //propiedad que establece la relación entre tablas
        public Especie? Especie { get; set; }
        public Raza? Raza { get; set; }

    }
}
