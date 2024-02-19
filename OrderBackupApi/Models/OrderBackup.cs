using Shared.Enums;
using Shared.Message;

namespace OrderBackupApi.Models
{
    public class OrderBackup
    {
        public int Id { get; set; }

        public State State { get; set; }

        public List<OrderBackupContent> OrderBackupContents { get; set; }
    }
}
