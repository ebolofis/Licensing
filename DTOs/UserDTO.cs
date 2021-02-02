using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPosLicense.DTOs
{

    [Table("Users")]
    public class UserDTO
    {
        [Column("ref")]
        [Key]
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ChangePasswordFlag { get; set; }
        public bool IsAdmin { get; set; }
    }
}
