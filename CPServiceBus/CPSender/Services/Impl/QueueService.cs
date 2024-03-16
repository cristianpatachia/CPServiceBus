using CPSender.Services.Interfaces;
using CPShared.Constants;
using CPShared.Extensions;
using CPShared.Models;
using Microsoft.Azure.ServiceBus;

namespace CPSender.Services.Impl
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _config;

        public QueueService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName) 
            where T : BaseMessage
        {
            var queueClient = new QueueClient(
                connectionString: _config.GetConnectionString(name: Constants.AzureServiceBus),
                entityPath: queueName);

            serviceBusMessage.SerializeIntoMessage(out Message message);
            
            await queueClient.SendAsync(message);
        }

        public async Task PublishPaymentMesssage<T>(T message, string queueName = Constants.PaymentQueue) 
            where T : BaseMessage
        {
            await this.SendMessageAsync(message, queueName);
        }
    }
}
