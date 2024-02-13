using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class RabbitMQSettings
    {
        public const string Basket_ItemAddedEventQueue = "basket-item-added-event-queue";

        public const string Basket_ViewRequestEventQueue = "Basket-view-event-queue";

        public const string Basket_ViewResponseEventQueue = "Basket-view-response-event-queue";

        public const string Basket_DeleteRequestEventQueue = "Basket-delete-request-event-queue";

        public const string Order_AddRequestEventQueue = "order-add-request-event-queue";
    }
}
