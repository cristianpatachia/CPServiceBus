using System.ComponentModel.DataAnnotations;
using CPShared.Helpers.DataAnnotations;

namespace CPShared.Models
{
    public class Payment : Transaction
    {
        public string From { get; set; }

        public string To { get; set; }

        public decimal? Amount { get; set; }
    }
}
