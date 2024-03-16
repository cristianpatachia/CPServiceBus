using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace CPShared.Extensions
{
    public static class MessageExtensions
    {
        public static bool TryGetDeserializedBody<T>(this Message message, out T deserializedBody)
        {
            deserializedBody = default(T);

            if (message is null || message.Body is null)
            {
                return false;
            }

            try
            {
                var jsonString = Encoding.UTF8.GetString(message.Body);
                deserializedBody = JsonSerializer.Deserialize<T>(jsonString);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SerializeIntoMessage<T>(this T serviceBusMessage, out Message message)
        { 
            var jsonString = JsonSerializer.Serialize<T>(serviceBusMessage);
            var encodedArray = Encoding.UTF8.GetBytes(jsonString);

            message = new Message(body: encodedArray);
        }
    }
}
