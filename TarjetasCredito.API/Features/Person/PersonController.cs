using Microsoft.AspNetCore.Mvc;
using TarjetasCredito.API.Features.Person;

namespace TarjetasCredito.API.Features.CreditCard
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(PersonService personService, CreditCardService creditCardService) : ControllerBase
    {
        [HttpGet("{id}")]
        public Person.Person GetCreditCard(string id)
        {
            return personService.GeneratePerson();
        }

        [HttpGet("{id}/tcs")]
        public List<CreditCard> GetCreditCards(string id) 
        {
            return creditCardService.GenerateCreditCards(2);
        }

        [HttpPost("{id}/tcs")]
        public IActionResult AddCreditCard()
        {
            var x = creditCardService.GenerateCreditCard();
            x.CreditCardCharges.Clear();
            x.Enabled = true;

            return Ok(x);
        }
    }
}
