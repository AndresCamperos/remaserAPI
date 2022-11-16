using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaserAPI.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Condominium")]
        public int CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int Alicuot { get; set; }
    }
}
