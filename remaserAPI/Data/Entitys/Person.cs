using System;

namespace remaserAPI.Data.Entitys
{
    public class Person
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
