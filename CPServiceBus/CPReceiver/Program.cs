using CPShared.Constants;
using CPShared.Extensions;
using CPShared.Models;
using Microsoft.Azure.ServiceBus;

namespace CPReceiver
{
    public static class Program
    {
        private static IQueueClient _queueClient;
        private static string _azureServiceBusConnectionString = "removed";

        public static async Task Main(string[] args)
        {
            _queueClient = new QueueClient(
                connectionString: _azureServiceBusConnectionString,
                entityPath: Constants.PaymentQueue);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionHandlerOptions)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };

            _queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await _queueClient.CloseAsync();
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            if (message.TryGetDeserializedBody(out Payment payment))
            {
                Console.WriteLine(
                    "Received Payment Ammount: '{0}', From: '{1}', To: '{2}'."
                        .F(payment.Amount,
                            payment.From,
                            payment.To));

                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
        }

        private static Task ExceptionHandlerOptions(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine("Message Handler Exception: {0}".F(arg.Exception));

            return Task.CompletedTask;
        }
    }
}