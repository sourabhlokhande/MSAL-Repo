using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Service
{
    public interface IBookService
    {
        string AddBook(Books book);
        string DeleteBook(long bookId);
        IEnumerable<Books> GetBooks();
        string UpdateBook(Books book);
    }
}