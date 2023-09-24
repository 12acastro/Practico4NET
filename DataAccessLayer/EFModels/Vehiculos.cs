using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.EFModels
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        [MaxLength(128), MinLength(3), Required]
        public string Marca { get; set; } = "-- Sin Marca --";
        [MaxLength(128), MinLength(3), Required]
        public string Modelo { get; set; } = "-- Sin Modelo --";
        [MaxLength(128), MinLength(3), Required]
        public string Matricula { get; set; } = "-- Sin Matricula --";
        public long? PersonaId { get; set; } = null;

        [ForeignKey("PersonaId")]
        
        public Personas? Persona { get; set; }


    }
}
