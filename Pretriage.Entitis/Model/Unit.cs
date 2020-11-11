using System.ComponentModel.DataAnnotations.Schema;

namespace Pretriage.Entitis.Model
{
    [Table("Unit")]
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
