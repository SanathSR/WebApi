using BookStoreManagement.BusinessLayer;
using BookStoreManagement.CustomExceptions;
using BookStoreManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
/*using System.Collections.Generic;*/
using System.Threading.Tasks;
/*using System.Web.Http;
using System.Web.Http.Description;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPatchAttribute = System.Web.Http.HttpPatchAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;*/

namespace BookStoreManagement.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookStoreManagementBL _Services;

        public BooksController(IBookStoreManagementBL bookStoreManagementBL)
        {
            _Services = bookStoreManagementBL;
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook(Books bookObj)
        {
            try
            {
                return Ok(await _Services.AddBook(bookObj));
            }
            catch (DuplicateBookNameException ex)
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

        [HttpPatch]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Books bookObj)
        {
            try
            {
                return Ok(await _Services.UpdateBook(bookObj));
            }
            catch (BookNotFoundException ex)
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


        /* [ResponseType(typeof(IEnumerable<Books>))]
         public async Task<IHttpActionResult> GetAllBooks()
         {

                 var results = await _Services.GetAllBooks();
             return (IHttpActionResult)Ok(results);
         }*/

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _Services.GetAllBooks());
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
        [Route("GetBooksCountForRent")]
        public async Task<IActionResult> GetBooksCountForRent()
        {
            try
            {
                return Ok(await _Services.GetBooksCountForRent());
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
        [Route("GetBooksCountForSale")]
        public async Task<IActionResult> GetBooksCountForSale()
        {
            try
            {
                return Ok(await _Services.GetBooksCountForSale());
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
        [Route("GetBooksNonSelected")]
        public async Task<IActionResult> GetBooksNonSelected()
        {
            try
            {
                return Ok(await _Services.GetBooksNonSelected());
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
