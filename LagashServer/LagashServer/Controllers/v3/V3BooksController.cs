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
using Wolf.Lagash.Interfaces.map;
using Wolf.Lagash.Entities.map;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v3/browser/books")]
    public class V3BooksController : ApiController
    {
        private IBookService service_books = new BookService(new LagashContext());
        private IBookCatalogService service_catalogs = new BookCatalogService(new LagashContext());
        private IAuthorService service_authors = new AuthorService(new LagashContext());
        private IAuthorMapService service_authors_map = new AuthorMapService(new LagashContext());
        private IBookEjemplarService service_ejemplares = new BookEjemplarService(new LagashContext());

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
            return service_ejemplares.get_asc(o => o.data_id == id, o => o.order);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Book> GetPagination(int page, int limit, string type, string search)
        {
            if (search == null) search = "";
            Func<Book, bool> where = null;
            switch (type)
            {
                case "ALL":
                    where = (o) => {
                        return o.title.ToLower().Contains(search.ToLower()) || (o.tags != null && o.tags.ToLower().Contains(search.ToLower()));
                    };
                    break;
                case "TITLE":
                    where = (o) => {
                        return o.title.ToLower().Contains(search.ToLower());
                    };
                    break;
                case "SUBJECT":
                    where = (o) => {
                        return o.tags != null && o.tags.ToLower().Contains(search.ToLower());
                    };
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            return service_books.search(page, limit, where);
        }

        [Route("catalogs/page/{page}/limit/{limit}")]
        public IEnumerable<BookCatalog> GetCatalogs(int page, int limit)
        {
            return service_catalogs.Where(page, limit, (o) => {
                return o.enabled == true;
            }, o => o.created);
        }

        [Route("catalogs/{id}")]
        public IEnumerable<Book> GetCatalogs(String id)
        {
            return service_books.get_desc(o => o.catalog_id == id, o => o.created);
        }

        [Route("{id}/authors")]
        public IEnumerable<Author> GetAuthors(string id)
        {
            IEnumerable<AuthorMap> items = service_authors_map.Query(o => o.resource_id == id);
            List<Author> result = new List<Author>();
            foreach (var item in items)
            {
                Author author = service_authors.FindById(item.author_id);
                author.map = item;
                result.Add(author);
            }
            return result;
        }
    }
}