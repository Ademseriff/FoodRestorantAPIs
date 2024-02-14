using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace OrderApi.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TotalPrice { get; set; }

        public Category Category { get; set; }

        public string Product { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }



        public int OrderAddId { get; set; }

        [ForeignKey("OrderAddId")]
        public OrderAdd OrderAdd { get; set; }
    }
}
