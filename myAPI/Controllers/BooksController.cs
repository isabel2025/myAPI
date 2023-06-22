using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myAPI.Models;

namespace myAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private WebAPIDataContext _webAPIDataContext;

        public BooksController(WebAPIDataContext webAPIDataContext)
        {
            _webAPIDataContext = webAPIDataContext;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _webAPIDataContext.Books.AsEnumerable();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _webAPIDataContext.Books.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _webAPIDataContext.Add(book);
            _webAPIDataContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book book)
        {
            var selectedBook = _webAPIDataContext.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(selectedBook != null)
            {
                _webAPIDataContext.Entry(selectedBook).Context.Update(book);
                _webAPIDataContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _webAPIDataContext.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                _webAPIDataContext.Books.Remove(book);
                _webAPIDataContext.SaveChanges();
            }

                


        }



    }
}

