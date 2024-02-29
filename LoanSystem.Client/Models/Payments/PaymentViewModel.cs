namespace LoanSystem.Client.Models.Payments
{
    public class PaymentViewModel
    {
        public decimal Amount { get; set; }

        public string? RequestType { get; set; } 

        public DateTime Date { get; set; }
    }
}
