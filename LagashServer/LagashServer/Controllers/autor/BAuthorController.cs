using LagashServer.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Interfaces;
using Wolf.Lagash.Services;

namespace LagashServer.Controllers.books
{
    public class BAuthorController : ApiController
    {
        private IEjemplaresService service = new EjemplaresService(new LagashContext());

        [Route("v2/books/{id}/author")]
        public IEnumerable<Ejemplar> Get(string id)
        {
            return service.Query(o => o.book_id == id);
        }

        [Route("v2/author")]
        public IEnumerable<Ejemplar> Get(string search)
        {
            return service.Query(o => o.book_id == id);
        }
    }
}
