using ContactsManagement.Application.DTOs;
using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactsManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController
        : ControllerBase
    {
        private readonly ICreateContactHandler _createContactHandler;
        private readonly IGetContactBydIdHandler _getContactBydIdHandler;

        public ContactsController(
            ICreateContactHandler createContactHandler,
            IGetContactBydIdHandler getContactBydIdHandler)
        {
            _createContactHandler = createContactHandler;
            _getContactBydIdHandler = getContactBydIdHandler;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(BaseReponse))]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateContactRequest request)
        {
            return Created(
                string.Empty,
                await _createContactHandler.HandleAsync(request));
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(BaseReponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] string id)
        {
            if (await _getContactBydIdHandler.HandleAsync(new GetContactBydIdRequest { Id = id }) is var result && result is null)
                return NotFound(null);

            return Ok(result);
        }
    }
}
