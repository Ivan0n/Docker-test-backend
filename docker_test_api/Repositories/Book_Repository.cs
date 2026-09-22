using docker_test_api.Models;
using Microsoft.EntityFrameworkCore;
using static docker_test_api.Repositories.Book_Repository;

namespace docker_test_api.Repositories
{
    public class Book_Repository (ApplicationDbContext context)
    {
        
        public async Task<List<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }
        public async Task<Book?> GetBookAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }
        public async Task AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetBookAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();

            }
        }

        public async Task<bool> ExistsAsync(int id) => await context.Books.AnyAsync(b => b.Id == id);
        
    }
}
