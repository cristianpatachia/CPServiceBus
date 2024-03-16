namespace CPShared.Models
{
    public class Transaction : BaseMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DateTimeUtc { get; set; } = DateTime.UtcNow;
    }
}
