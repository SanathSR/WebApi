using BookStoreManagement.BusinessLayer;
using BookStoreManagement.CustomExceptions;
using BookStoreManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStoreManagement.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscationsController : ControllerBase
    {
        private readonly IBookStoreManagementBL _Services;

        public TranscationsController(IBookStoreManagementBL bookStoreManagementBL)
        {
            _Services = bookStoreManagementBL;
        }

        [HttpPost]
        [Route("AddTranscation")]
        public async Task<IActionResult> AddTranscation(Transcations transcationObj)
        {
            try
            {
                return Ok(await _Services.AddTranscation(transcationObj));
            }
            catch(InvalidUserIdException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidBookIdException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (QuantityException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidAvilableForException ex)
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
        [Route("GetAllTranscation")]
        public async Task<IActionResult> GetAllTranscation()
        {
            try
            {
                return Ok(await _Services.GetAllTranscation());
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
        [Route("GetFineDetailsBasedOnBookId")]
        public async Task<IActionResult> GetFineDetailsBasedOnBookId(int transactionId, int bookId, int userId)
        {
            try
            {
                return Ok(await _Services.GetFineDetailsBasedOnBookId(transactionId, bookId, userId));
            }
            catch (SqlExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (TransactionIdInvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BookNotAvailableForThatPurposeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoDataPresentException ex)
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
