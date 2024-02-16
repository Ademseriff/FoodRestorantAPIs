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

        public const string Order_ViewRequestEventQueue = "order-view-request-event-queue";

        public const string Admin_ViewResponseEventQueue = "order-view-response-event-queue";

        public const string Order_OrderComplatedEventQueue = "order-complated-event-queue";

        public const string Order_OrderFailedEventQueue = "order-failed-event-queue";

        public const string Order_OrderViewComplatedEventQueue = "order-complatedview-event-queue";

        public const string Admin_OrderViewComplatedResponseEventQueue = "order-complatedview-response-event-queue";

        public const string Mail_SentEventQueue = "mail-sent-event-queue";
    }
}
