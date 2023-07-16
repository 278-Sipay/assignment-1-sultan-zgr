using assignment_1_sultan_zg.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_1_sultan_zg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> _personValidator;

        public PersonController(IValidator<Person> personValidator)
        {
            _personValidator = personValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            var validationResult = _personValidator.Validate(person);

            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.Select(e => e.ErrorMessage);     //Validasyonda yazdığımız hataları dönüyoruz
                return BadRequest(new { Errors = error });
            }

            return Ok(new { Message = "Transaction Successfull :)" });
        }


    }
}