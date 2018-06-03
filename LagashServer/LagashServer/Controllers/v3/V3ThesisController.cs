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
    [RoutePrefix("v3/browser/thesis")]
    public class V3ThesisController : ApiController
    {
        private IThesisService service_thesis = new ThesisService(new LagashContext());
        private IThesisCatalogService service_catalogs = new ThesisCatalogService(new LagashContext());
        private IEjemplarService service_ejemplares = new EjemplarService(new LagashContext());

        [Route("{id}")]
        public IHttpActionResult Get(String id)
        {
            Thesis item = service_thesis.FindById(id);
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

        //[Route("page/{page}/limit/{limit}")]
        //public IEnumerable<Thesis> GetPagination(int page, int limit, string search)
        //{
        //    if (search == null) search = "";
        //    return service_thesis.search(page, limit, (o) => {
        //        return o.title.ToLower().Contains(search.ToLower());
        //    });
        //}

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Thesis> GetPagination(int page, int limit, string type, string search)
        {
            if (search == null) search = "";
            Func<Thesis, bool> where = null;
            switch (type) {
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
            return service_thesis.search(page, limit, where);
        }

        [Route("suggestions")]
        public IEnumerable<Thesis> GetSuggestions()
        {
            return service_thesis.suggestions();
        }

        [Route("catalogs/page/{page}/limit/{limit}")]
        public IEnumerable<ThesisCatalog> GetCatalogs(int page, int limit)
        {
            return service_catalogs.Where(page, limit, (o) => {
                return o.enabled == true;
            }, o => o.created);
        }

        [Route("catalogs/{id}")]
        public IEnumerable<Thesis> GetCatalogs(String id)
        {
            return service_thesis.get(o => o.catalog_id == id, o => o.created);
        }
    }
}