namespace TarjetasCredito.API.Features.CreditCard
{
    public class CreditCardCharge
    {
        public long Id { get; set; }

        public int Price { get; set; }

        public int Installments { get; set; }

        //public int InstallmentsPaid { get; set; }

        public string? Business {  get; set; }

        public DateOnly DateOfPurchase { get; set; }
    }
}