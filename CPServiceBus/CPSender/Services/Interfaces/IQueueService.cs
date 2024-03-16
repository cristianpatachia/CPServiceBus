using CPShared.Models;
using CPShared.Constants;

namespace CPSender.Services.Interfaces
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string queueName) where T : BaseMessage;

        Task PublishPaymentMesssage<T>(T message, string queueName = Constants.PaymentQueue) where T : BaseMessage;
    }
}