using BookStoreManagement.BusinessLayer;
using BookStoreManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BookStoreManagement.CustomExceptions;

namespace BookStoreManagement.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IBookStoreManagementBL _Services;

        public UsersController(IBookStoreManagementBL bookStoreManagementBL)
        {
            _Services = bookStoreManagementBL;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(Users usersObj)
        {
            try
            {
                return Ok(await _Services.AddUser(usersObj));
            }
            catch(DuplicateUserNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(SqlExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPatch]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(Users usersObj)
        {
            try
            {
                return Ok(await _Services.UpdateUser(usersObj));
            }
            catch(UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                return Ok(await _Services.DeleteUser(userId));
            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _Services.GetAllUsers());
            }
            catch (SqlExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
