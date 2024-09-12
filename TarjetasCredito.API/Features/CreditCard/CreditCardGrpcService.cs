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
                ExpirationDate = result.ExpirationDate.ToString("MM/yy"),
                Enabled = result.Enabled,
                Issuer = result.Issuer
            };

            reply.CreditCardCharges.AddRange(
                result.CreditCardCharges.Select(x => new GrpcCreditCard.CreditCardCharge
                {
                    Id = (int) x.Id,
                    Price = x.Price,
                    Installments = x.Installments,
                    Business = x.Business,
                    DateOfPurchase = new ChargeDate
                    {
                        Year = x.DateOfPurchase.Year,
                        Month = x.DateOfPurchase.Month,
                        Day = x.DateOfPurchase.Day,
                        DayOfWeek = (int) x.DateOfPurchase.DayOfWeek,
                        DayOfYear = x.DateOfPurchase.DayOfYear,
                        DayNumber = x.DateOfPurchase.DayNumber
                    }
                }));

            return Task.FromResult(reply);
        }

        public override Task<PayCreditCardReply> PayCreditCard(PayCreditCardRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PayCreditCardReply
            {
                Message = $"Payment of $ {request.Amount} for credit card with Id {request.Id} was successful."
            });
        }

        public override Task<SetCardStatusReply> SetCardStatus(SetCardStatusRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SetCardStatusReply
            {
                Message = $"The credit card with Id {request.Id} is now {(request.Enabled ? "Enabled" : "Disabled")}"
            });
        }
    }
}
