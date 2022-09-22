using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Service
{
    public interface IBookService
    {
        Task<string> AddBook(Books book);
        Task<string> DeleteBook(long bookId);
        Task<IEnumerable<Books>> GetBooks();
        Task<string> UpdateBook(Books book);
    }
}