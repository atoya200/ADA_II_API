using Microsoft.AspNetCore.Mvc;

namespace TarjetasCredito.API.Features.CreditCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController(CreditCardService creditCardService) : ControllerBase
    {
        [HttpGet("{id}")]
        public CreditCard GetCreditCard(string id)
        {
            return creditCardService.GenerateCreditCard();
        }
    }
}
