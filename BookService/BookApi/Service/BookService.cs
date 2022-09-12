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

        public string AddBook(Books book)
        {
            try
            {
                _dbContext.BookTbl.Add(book);
                _dbContext.SaveChanges();
                return $"{book.title} has been added";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public string DeleteBook(long bookId)
        {
            try
            {
                var bookObj = _dbContext.BookTbl.Find(bookId);
                if(bookObj != null)
                {
                    _dbContext.Remove(bookObj);
                }
                _dbContext.SaveChanges();
                return $"book has been deleted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Books> GetBooks()
        {
            try
            {
                return _dbContext.BookTbl.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateBook(Books book)
        {
            try
            {
                var bookObj = _dbContext.BookTbl.Find(book.bookId);
                if(bookObj != null )
                {
                    bookObj.title = book.title;
                }
                _dbContext.SaveChanges();
                return $"book has been updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
