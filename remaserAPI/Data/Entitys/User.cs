using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace remaserAPI.Data.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public bool EnableUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
