using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaserAPI.Models
{
    public class Apartament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }        
        public Owner Owner { get; set; }
        public int Alicuot { get; set; }
    }
}
