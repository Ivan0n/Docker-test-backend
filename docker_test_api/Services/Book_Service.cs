using docker_test_api.DTOS;
using docker_test_api.Repositories;
namespace docker_test_api.Services
{
    public class Book_Service (Book_Repository repository, MappingService mappingService)
    {
        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            return mappingService.MapBookList(await repository.GetAllAsync());
        }

        public async Task<BookDTO?> GetBookByIdAsync(int id)
        {
            var book = await repository.GetBookAsync(id);
            return book == null ? null : mappingService.MapBook(book);
        }

        public async Task<BookDTO> CreateBookAsync(CreateBookDTO dto)
        {
            var book = mappingService.MapBookDto(dto);
            await repository.AddAsync(book);

            return mappingService.MapBook(book);
        }

        public async Task UpdateBookAsync(UpdateBookDto dto)
        {
            await repository.UpdateAsync(mappingService.MapBookDto(dto));
        }

        public async Task DeleteBookAsync(int id)
        {

            await repository.DeleteAsync(id);
        }
    }
}
