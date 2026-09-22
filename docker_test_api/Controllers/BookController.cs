using Microsoft.AspNetCore.Mvc;
using docker_test_api.Services;
using docker_test_api.DTOS;

namespace docker_test_api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : Controller
    {
        
       
            private readonly Book_Service _bookService;

            public BookController(Book_Service bookService)
            {
                _bookService = bookService;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }

            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<BookDTO>> GetBookById(int id)
            {
                var book = await _bookService.GetBookByIdAsync(id);

                if (book == null)
                    return NotFound(new { message = $"Книга с ID {id} не найдена" });

                return Ok(book);
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<BookDTO>> CreateBook([FromBody] CreateBookDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdBook = await _bookService.CreateBookAsync(dto);

                return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
            }
            [HttpPut]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    await _bookService.UpdateBookAsync(dto);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound(new { message = $"Книга с ID {dto.Id} не найдена" });
                }
            }

            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> DeleteBook(int id)
            {
                try
                {
                    await _bookService.DeleteBookAsync(id);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound(new { message = $"Книга с ID {id} не найдена" });
                }
            }
        }

    }
    
