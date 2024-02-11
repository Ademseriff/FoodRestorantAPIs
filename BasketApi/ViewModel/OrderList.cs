using Shared.Enums;

namespace BasketApi.ViewModel
{
    public class OrderList
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Price { get; set; }

        public string Product { get; set; }
    }
}
