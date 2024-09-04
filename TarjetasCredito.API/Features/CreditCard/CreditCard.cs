namespace TarjetasCredito.API.Features.CreditCard
{
    public class CreditCard
    {
        public int Id { get; set; }

        public long Number { get; set; }

        public int Limit { get; set; }

        public Person.Person? Person { get; set; }

        public int CloseDate { get; set; }

        public DateOnly ExpirationDate { get; set; }

        public bool Enabled { get; set; }

        public string? Issuer { get; set; }

        public List<CreditCardCharge>? CreditCardCharges { get; set; }
    }
}