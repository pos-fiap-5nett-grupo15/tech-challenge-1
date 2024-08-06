using ContactsManagement.Application.DTOs;
using ContactsManagement.Application.DTOs.Contact.CreateContact;
using ContactsManagement.Application.DTOs.Contact.DeleteContactById;
using ContactsManagement.Application.DTOs.Contact.GetContactBydId;
using ContactsManagement.Application.DTOs.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.DTOs.Contact.UpdateContactById;
using ContactsManagement.Application.Interfaces.Contact.CreateContact;
using ContactsManagement.Application.Interfaces.Contact.DeleteContactById;
using ContactsManagement.Application.Interfaces.Contact.GetContactBydId;
using ContactsManagement.Application.Interfaces.Contact.GetContatListPaginatedByFilters;
using ContactsManagement.Application.Interfaces.Contact.UpdateContactById;
using ContactsManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IDeleteContactByIdHandler _deleteContactByIdHandler;
        private readonly IUpdateContactByIdHandler _updateContactByIdHandler;
        private readonly IGetContactListPaginatedByFiltersHandler _getContatListPaginatedByFiltersHandler;

        public ContactsController(
            ICreateContactHandler createContactHandler,
            IGetContactBydIdHandler getContactBydIdHandler,
            IDeleteContactByIdHandler deleteContactByIdHandler,
            IUpdateContactByIdHandler updateContactByIdHandler,
            IGetContactListPaginatedByFiltersHandler getContatListPaginatedByFiltersHandler)
        {
            _createContactHandler = createContactHandler;
            _getContactBydIdHandler = getContactBydIdHandler;
            _deleteContactByIdHandler = deleteContactByIdHandler;
            _updateContactByIdHandler = updateContactByIdHandler;
            _getContatListPaginatedByFiltersHandler = getContatListPaginatedByFiltersHandler;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(BaseReponse))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateContactRequest request)
        {
            return Created(string.Empty, await _createContactHandler.HandleAsync(request));
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(BaseReponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id)
        {
            if (await _getContactBydIdHandler.HandleAsync(new GetContactBydIdRequest { Id = id }) is var result && result is null)
                return NotFound(null);

            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetListPaginatedByFiltersAsync(
            [FromQuery] GetContatListPaginatedByFiltersRequest body)
        {
            return Ok(await _getContatListPaginatedByFiltersHandler.HandleAsync(body));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = nameof(EUserType.Administrator))]
        public async Task<IActionResult> DeleteByIdAsync(
            [FromRoute] int id)
        {
            return Ok(await _deleteContactByIdHandler.HandleAsync(new DeleteContactByIdRequest { Id = id }));
        }

        [HttpPatch("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(BaseReponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = nameof(EUserType.Administrator))]
        public async Task<IActionResult> UpdateByIdAsync(
            [FromRoute] int id,
            [FromBody] UpdateContactByIdRequest body)
        {
            body.Id = id;
            if (await _updateContactByIdHandler.HandleAsync(body) is var result && result is null)
                return NotFound(null);

            return NoContent();
        }
    }
}
