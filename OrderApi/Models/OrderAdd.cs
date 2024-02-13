using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderApi.Enums;

namespace OrderApi.Models
{
    public class OrderAdd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public State State { get; set; }
        // Diğer özellikler buraya eklenebilir

        // Bire çok ilişki için referans özelliği
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
