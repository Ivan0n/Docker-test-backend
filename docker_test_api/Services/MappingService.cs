using docker_test_api.Models;
using docker_test_api.DTOS;
namespace docker_test_api.Services
{
    public class MappingService
    {

        public BookDTO MapBook(Book book) => new()
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            CreatedDate = book.CratedDate
        };

        public List<BookDTO> MapBookList(List<Book> books) => books.Select(MapBook).ToList();

        public Book MapBookDto(CreateBookDTO dto) => new()
        {
            Name = dto.Name,
            Author = dto.Author,
            CratedDate = dto.CreatedDate
        };
        public Book MapBookDto(UpdateBookDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Author = dto.Author,
            CratedDate = dto.CreatedDate
        };

    }
}   
