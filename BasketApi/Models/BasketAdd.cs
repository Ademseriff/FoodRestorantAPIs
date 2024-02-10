using BasketApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketApi.Models
{
    public class BasketAdd
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public FoodCategory Category { get; set; }

        public string Price { get; set; }

        public string Product { get; set; }

    }
}
