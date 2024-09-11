using Bogus;
using TarjetasCredito.API.Features.Person;
using TarjetasCredito.API.Features.Rng;
using TarjetasCredito.API.Features.GrpcCreditCard;
using TarjetasCredito.API.Features.GrpcPerson;
using Grpc.Core;

namespace TarjetasCredito.API.Features.CreditCard
{
    public class CreditCardService
    {
        private readonly Faker<CreditCard> _faker;
        private readonly RngService _rngService;
        private readonly PersonService _personService;
        private readonly CreditCardChargesService _creditCardChargesService;

        public CreditCardService(RngService rngService, PersonService personService, CreditCardChargesService creditCardChargesService)
        {
            _rngService = rngService;
            _personService = personService;
            _creditCardChargesService = creditCardChargesService;

            _faker = new Faker<CreditCard>()
                .RuleFor(p => p.Id, f => _rngService.GetRandomInt(100_000_000, 999_999_999))
                .RuleFor(p => p.Number, f => _rngService.GetRandomLong(1_000_000_000_000, 9_999_000_000_000))
                .RuleFor(p => p.Limit, f => _rngService.GetRandomInt(0, 1_000_000))
                .RuleFor(p => p.Person, _personService.GeneratePerson())
                .RuleFor(p => p.Id, f => _rngService.GetRandomInt(0, 1_000_000))
                .RuleFor(p => p.CloseDate, f => _rngService.GetRandomInt(1, 31))
                .RuleFor(p => p.ExpirationDate, f => f.Date.FutureDateOnly())
                .RuleFor(p => p.Enabled, f => f.Random.Bool())
                .RuleFor(p => p.Issuer, f => f.PickRandom("Visa", "MasterCard", "American Express"))
                .RuleFor(p => p.CreditCardCharges, f => _creditCardChargesService.GenerateCharges(10));
        }

        public CreditCard GenerateCreditCard()
        {
            return _faker.Generate();
        }

        public List<CreditCard> GenerateCreditCards(int amount)
        {
            return _faker.Generate(amount).ToList();
        }
    }
}
