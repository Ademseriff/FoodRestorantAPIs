using Shared.Enums;

namespace OrderBackupApi.Models
{
    public class OrderBackupContent
    {
        public string TotalPrice { get; set; }

        public Category Category { get; set; }

        public string Product { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }


        public string Email { get; set; }
    }
}
