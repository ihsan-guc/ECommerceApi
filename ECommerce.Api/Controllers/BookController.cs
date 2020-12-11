using ECommerce.Api.Core;
using ECommerce.Api.Models.Requests;
using ECommerce.Api.Models.Response;
using ECommerce.Data.Domain.Entities;
using Message.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        /// <summary>
        /// Kitap Getirir.
        /// </summary>
        /// <param name="BookHome"></param>
        /// Post: api/book/BookHome
        [HttpGet]
        [Route("BookHome")]
        public ActionResult BookHome()
        {
            if (ModelState.IsValid)
            {
                var bookList = UnitOfWork.BookRepository.GetList().ToList();
                return Ok(new BooksResponse() { IsSuccess = true, Message = "Başarılı", BookList = bookList });
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kitap Arama.
        /// </summary>
        /// <param name="BookSearch"></param>
        /// Post: api/book/bookSearch
        [HttpPost]
        [Route("bookSearch")]
        public ActionResult BookSearch(BookSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                var bookList = UnitOfWork.BookRepository.GetQueryable().Where(p=>p.Name.Contains(model.BookName)).ToList();
                return Ok(new BookSearchResponse() { IsSuccess = true, Message = "Başarılı" , BookList = bookList});
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Listelenen Kitapları O sayıya göre Sıralar.
        /// </summary>
        /// <param name="BookNumberSearch"></param>
        /// Post: api/book/bookNumberSearch
        [HttpPost]
        [Route("bookNumberSearch")]
        public ActionResult BookNumberSearch(BookNumberSearchRequest model)
        {
            if (ModelState.IsValid)
            {
                var bookList = UnitOfWork.BookRepository.GetQueryable().Take(model.PageSize).ToList();
                return Ok(new BookSearchResponse() { IsSuccess = true, Message = "Başarılı", BookList = bookList });
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kategorileri Getirir.
        /// </summary>
        /// <param name="BookCategorySearch"></param>
        /// Post: api/book/bookCategorySearch
        [HttpPost]
        [Route("bookCategorySearch")]
        public ActionResult BookCategorySearch()
        {
            if (ModelState.IsValid)
            {
                var bookList = UnitOfWork.BookCategoryRepository.GetQueryable().ToList();
                return Ok(new BookCategorySearchResponse() { IsSuccess = true, Message = "Başarılı", BookCategories = bookList });
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kategorileri Göre Kitapları getirir.
        /// </summary>
        /// <param name="BookCategoryPage"></param>
        /// Post: api/book/bookCategoryPage
        [HttpPost]
        [Route("bookCategoryPage")]
        public ActionResult BookCategoryPage(GetBookCategoryBooksRequest model)
        {
            if (ModelState.IsValid)
            {
                var bookList = UnitOfWork.BookRepository.GetQueryable().Where(p=>p.BookCategoryId == model.CategoryId).ToList();
                return Ok(new BooksResponse() { IsSuccess = true, Message = "Başarılı", BookList = bookList });
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kitap Id ile Detaya Gidilir.
        /// </summary>
        /// <param name="GetBookDetail"></param>
        /// Post: api/book/getBookDetail
        [HttpPost]
        [Route("getBookDetail")]
        public ActionResult GetBookDetail(GetBookDetailRequest model)
        {
            if (ModelState.IsValid)
            {
                var book = UnitOfWork.BookRepository.GetQueryable().Where(p => p.Id == model.BookId).FirstOrDefault();
                return Ok(new BookResponse() { IsSuccess = true, Message = "Başarılı",  Book = book});
            }
            return Ok(ReturnValid());
        }

    }
}
