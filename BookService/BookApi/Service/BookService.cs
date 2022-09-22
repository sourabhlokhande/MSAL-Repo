using BookApi.Data;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Service
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;
        public BookService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddBook(Books book)
        {
            try
            {
                await _dbContext.BookTbl.AddAsync(book);
                await _dbContext.SaveChangesAsync();
                return $"{book.title} has been added";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<string> DeleteBook(long bookId)
        {
            try
            {
                var bookObj = await _dbContext.BookTbl.FindAsync(bookId);
                if(bookObj != null)
                {
                    _dbContext.Remove(bookObj);
                }
                await _dbContext.SaveChangesAsync();
                return $"book has been deleted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            try
            {
                return await Task.Run(() => _dbContext.BookTbl.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateBook(Books book)
        {
            try
            {
                var bookObj = await _dbContext.BookTbl.FindAsync(book.bookId);
                if(bookObj != null )
                {
                    bookObj.title = book.title;
                    bookObj.genre = book.genre;
                    bookObj.author = book.author;
                    bookObj.price = book.price;
                }
                await _dbContext.SaveChangesAsync();
                return $"book has been updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
