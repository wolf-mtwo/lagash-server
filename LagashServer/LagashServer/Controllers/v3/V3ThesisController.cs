﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Services.helpers.author;
using Wolf.Lagash.Services.thesis;
using Wolf.Lagash.Interfaces.thesis;
using Wolf.Lagash.Interfaces.helpers.author;

namespace LagashServer.Controllers.v3
{
    [RoutePrefix("v3/browser/thesis")]
    public class V3ThesisController : ApiController
    {
        private IThesisService service_thesis = new ThesisService(new LagashContext());
        private IThesisCatalogService service_catalogs = new ThesisCatalogService(new LagashContext());
        private IAuthorService service_authors = new AuthorService(new LagashContext());
        private IAuthorMapService service_authors_map = new AuthorMapService(new LagashContext());
        private IThesisEjemplarService service_ejemplares = new ThesisEjemplarService(new LagashContext());
        private IAuthorService service_author = new AuthorService(new LagashContext());
        private IAuthorMapService service_author_map = new AuthorMapService(new LagashContext());

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            Thesis item = service_thesis.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}/ejemplares")]
        public IEnumerable<Ejemplar> GetEjemplares(string id)
        {
            return service_ejemplares.get_asc(o => o.material_id == id && o.enabled == true, o => o.order);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Thesis> GetPagination(int page, int limit, string type, string search)
        {
            if (search == null) search = "";
            Func<Thesis, bool> where = null;
            switch (type)
            {
                case "ALL":
                    where = (o) =>
                    {
                        return o.title.ToLower().Contains(search.ToLower()) || o.tags != null && o.tags.ToLower().Contains(search.ToLower());
                    };
                    break;
                case "TITLE":
                    where = (o) =>
                    {
                        return o.title.ToLower().Contains(search.ToLower());
                    };
                    break;
                case "SUBJECT":
                    where = (o) =>
                    {
                        return o.tags != null && o.tags.ToLower().Contains(search.ToLower());
                    };
                    break;
                case "AUTHOR":
                    return find_by_autors(page, limit, search);
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            return service_thesis.search(page, limit, where);
        }

        private IEnumerable<Thesis> find_by_autors(int page, int limit, string search)
        {
            List<AuthorMap> list = new List<AuthorMap>();
            List<Author> authores = service_author.get_desc((o) =>
            {
                return o.first_name.ToLower().Contains(search.ToLower()) || o.last_name.ToLower().Contains(search.ToLower());
            }, o => o.created).ToList();
            authores.ForEach((author) =>
            {
                list.AddRange(service_author_map.get_desc(o => o.author_id == author._id, o => o.created).ToList());
            });
            List<Thesis> items = new List<Thesis>();
            int index = (page - 1) * limit;
            for (int i = index; i < page * limit; i++)
            {
                AuthorMap map = list.ElementAtOrDefault(i);
                if (map != null)
                {
                    items.Add(service_thesis.FindById(map.material_id));
                }
            }
            return items;
        }

        [Route("catalogs/page/{page}/limit/{limit}")]
        public IEnumerable<ThesisCatalog> GetCatalogs(int page, int limit)
        {
            return service_catalogs.Where(page, limit, (o) =>
            {
                return o.enabled == true;
            }, o => o.created);
        }

        [Route("catalogs/{id}")]
        public IEnumerable<Thesis> GetCatalogs(string id)
        {
            return service_thesis.get_desc(o => o.catalog_id == id, o => o.created);
        }

        [Route("{id}/authors")]
        public IEnumerable<Author> GetAuthors(string id)
        {
            IEnumerable<AuthorMap> items = service_authors_map.Query(o => o.material_id == id);
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