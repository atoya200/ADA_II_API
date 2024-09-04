using Bogus;
using TarjetasCredito.API.Features.Rng;

namespace TarjetasCredito.API.Features.CreditCard;

public class CreditCardChargesService
{
    private readonly Faker<CreditCardCharge> _faker;
    private readonly RngService _rngService;

    public CreditCardChargesService(RngService rngService)
    {
        _rngService = rngService;

        _faker = new Faker<CreditCardCharge>()
                .RuleFor(p => p.Id, f => _rngService.GetRandomLong(100_000_000_000_000, 999_999_999_999_999))
                .RuleFor(p => p.Price, f => _rngService.GetRandomInt(200, 100_000))
                .RuleFor(p => p.Installments, f => _rngService.GetRandomInt(0, 12))
                .RuleFor(p => p.Business, f => f.Company.CompanyName())
                .RuleFor(p => p.DateOfPurchase, f => f.Date.PastDateOnly());
    }

    public List<CreditCardCharge> GenerateCharges(int count)
    {
        return _faker.Generate(count).ToList();
    }
}
