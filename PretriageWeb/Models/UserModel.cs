using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.Models
{
    [Table("User")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
    }
}
