using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wolf.Lagash.Services;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using LagashServer.helper;
using Wolf.Lagash.Entities.books;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Interfaces.helper.ejemplar;
using Wolf.Lagash.Services.helper.ejemplar;
using Wolf.Lagash.Entities.helper.ejemplar;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v3/browser/books")]
    public class V3BrowserController : ApiController
    {
        private IBookService service_books = new BookService(new LagashContext());
        private IThesisService service_thesis = new ThesisService(new LagashContext());
        private IEjemplarService service_ejemplares = new EjemplarService(new LagashContext());

        [Route("{id}")]
        public IHttpActionResult Get(String id)
        {
            Book item = service_books.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}/ejemplares")]
        public IEnumerable<Ejemplar> GetEjemplares(String id)
        {
            return service_ejemplares.Query(o => o.data_id == id);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Book> GetPagination(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service_books.search(page, limit, (o) => {
                return o.title.ToLower().Contains(search.ToLower());
            });
        }

        [Route("suggestions")]
        public IEnumerable<Book> GetSuggestions()
        {
            return service_books.suggestions();
        }
    }
}