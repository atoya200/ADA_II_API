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

        [HttpPost("{id}/pay")]
        public IActionResult PayCreditCard(string id, int amount)
        {
            return Ok("Payment succesful");
        }

        [HttpPatch("{id}/SetStatus")]
        public IActionResult ChangeStatus(bool status)
        {
            string x = string.Empty;

            if (status)
            {
                x = "Enabled";
            }
            else
            {
                x = "Disabled";
            }

            return Ok($"The credit card is now {x}");
        }
    }
}
