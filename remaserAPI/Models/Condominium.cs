using System.ComponentModel.DataAnnotations.Schema;

namespace RemaserAPI.Models
{
    public class Condominium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        [ForeignKey("House")]
        public int HouseId { get; set; }
        public House House { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
