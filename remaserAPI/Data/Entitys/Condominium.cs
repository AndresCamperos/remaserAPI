using System.ComponentModel.DataAnnotations.Schema;

namespace remaserAPI.Data.Entitys
{
    public class Condominium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }       
    }
}
