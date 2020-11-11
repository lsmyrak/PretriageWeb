using System.ComponentModel.DataAnnotations.Schema;

namespace Pretriage.Entitis.Model
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
    }
}

