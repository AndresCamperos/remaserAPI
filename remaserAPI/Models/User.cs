using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaserAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
