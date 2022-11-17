using System.ComponentModel.DataAnnotations.Schema;

namespace remaserAPI.Data.Entitys
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Condominium")]
        public int CondominiumId { get; set; }

        public Condominium Condominium { get; set; }


    }
}
