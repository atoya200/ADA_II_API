using Grpc.Core;
using TarjetasCredito.API.Features.CreditCard;
using TarjetasCredito.API.Features.GrpcPerson;

namespace TarjetasCredito.API.Features.GrpcCreditCard
{
    public class CreditCardGrpcService(CreditCardService creditCardService) : CreditCardProtobuf.CreditCardProtobufBase
    {
        public override Task<GetCreditCardReply> GetCreditCard(GetCreditCardRequest request, ServerCallContext context)
        {
            CreditCard.CreditCard result = creditCardService.GenerateCreditCard();

            GetCreditCardReply reply = new GetCreditCardReply
            {
                Id = result.Id,
                Number = result.Number,
                Limit = result.Limit,
                Person = new GetPersonReply
                {
                    Id = result.Person.Id,
                    FirstName = result.Person.FirstName,
                    LastName = result.Person.LastName,
                    Email = result.Person.Email,
                    Phone = result.Person.Phone,
                },
                CloseDate = result.CloseDate,
                ExpirationDate = "11/2046",
                Enabled = result.Enabled,
                Issuer = result.Issuer
            };

            return Task.FromResult(reply);
        }
    }
}
