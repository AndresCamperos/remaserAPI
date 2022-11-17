using System.ComponentModel.DataAnnotations.Schema;

namespace remaserAPI.Data.Entitys
{
    public class Owner
    {
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

    }
}
