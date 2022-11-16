using System.ComponentModel.DataAnnotations.Schema;

namespace RemaserAPI.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Apartament")]
        public int ApartamentId { get; set; }
        
        public Apartament Apartament { get; set; }


    }
}
