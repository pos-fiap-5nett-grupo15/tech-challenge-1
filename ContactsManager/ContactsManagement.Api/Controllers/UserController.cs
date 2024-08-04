using ContactsManagement.Application.DTOs.User.CreateUser;
using ContactsManagement.Application.DTOs.User.DeleteUser;
using ContactsManagement.Application.DTOs.User.GetUser;
using ContactsManagement.Application.DTOs.User.GetUserList;
using ContactsManagement.Application.DTOs.User.UpdateUser;
using ContactsManagement.Application.Interfaces.User.CreateUser;
using ContactsManagement.Application.Interfaces.User.DeleteUser;
using ContactsManagement.Application.Interfaces.User.GetUser;
using ContactsManagement.Application.Interfaces.User.UpdateUser;
using ContactsManagement.Application.Interfaces.User.ValidateUser;
using ContactsManagement.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactsManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserHandler _createUserHandler;
        private readonly IUpdateUserHandler _updateUserHandler;
        private readonly IValidateUserHandler _validateUserHandler;
        private readonly IGetUserListHandler _getUserListHandler;
        private readonly IGetUserByIdHandler _getUserByIdHandler;
        private readonly IGetUserByNameHandler _getUserByNameHandler;
        private readonly IDeleteUserHandler _deleteUserHandler;

        public UserController(
            ICreateUserHandler createUserHandler,
            IUpdateUserHandler updateUserHandler,
            IValidateUserHandler validateUserHandler,
            IGetUserListHandler getUserListHandler,
            IGetUserByIdHandler getUserByIdHandler,
            IGetUserByNameHandler getUserByNameHandler,
            IDeleteUserHandler deleteUserHandler)
        {
            _createUserHandler = createUserHandler;
            _updateUserHandler = updateUserHandler;
            _validateUserHandler = validateUserHandler;
            _getUserListHandler = getUserListHandler;
            _getUserByIdHandler = getUserByIdHandler;
            _getUserByNameHandler = getUserByNameHandler;
            _deleteUserHandler = deleteUserHandler;
        }

        [HttpGet("all")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetUserList()
        {
            var userList = await _getUserListHandler.HandleAsync(new GetUserListRequest());

            if (userList != null && userList.Users.Count() > 0)
                return Ok(userList);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _getUserByIdHandler.HandleAsync(new GetUserByIdRequest() { Id = id });

            if (user is null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = nameof(EUserType.Administrator))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest requestBody)
        {
            if (await _getUserByNameHandler.HandleAsync(new GetUserByNameRequest() { Username = requestBody.UserName }) != null)
                return BadRequest("User already exists");

            await _createUserHandler.HandleAsync(requestBody);
            return Created();
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = nameof(EUserType.Administrator))]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest requestBody, [FromRoute] int id)
        {
            if (await _getUserByIdHandler.HandleAsync(new GetUserByIdRequest() { Id = id }) is null)
                return NotFound();
            else
            {
                requestBody.Id = id;
                await _updateUserHandler.HandleAsync(requestBody);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = nameof(EUserType.Administrator))]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (await _getUserByIdHandler.HandleAsync(new GetUserByIdRequest() { Id = id }) is null)
                return NotFound();
            else
            {
                await _deleteUserHandler.HandleAsync(new DeleteUserRequest() { Id = id });
                return NoContent();
            }
        }
    }
}