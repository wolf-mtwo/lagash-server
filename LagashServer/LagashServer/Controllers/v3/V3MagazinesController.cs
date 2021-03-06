﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Services.helpers.author;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Interfaces.magazine;
using Wolf.Lagash.Interfaces.helpers.author;

namespace LagashServer.Controllers.v3
{
    [RoutePrefix("v3/browser/magazines")]
    public class V3MagazinesController : ApiController
    {
        private IMagazineService service = new MagazineService(new LagashContext());
        private IMagazineCatalogService service_catalogs = new MagazineCatalogService(new LagashContext());
        private IAuthorService service_authors = new AuthorService(new LagashContext());
        private IAuthorMapService service_authors_map = new AuthorMapService(new LagashContext());
        private IMagazineEjemplarService service_ejemplares = new MagazineEjemplarService(new LagashContext());
        private IAuthorService service_author = new AuthorService(new LagashContext());
        private IAuthorMapService service_author_map = new AuthorMapService(new LagashContext());

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            Magazine item = service.FindById(id);
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
        public IEnumerable<Magazine> GetPagination(int page, int limit, string type, string search)
        {
            if (search == null) search = "";
            Func<Magazine, bool> where = null;
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
            return service.search(page, limit, where);
        }

        private IEnumerable<Magazine> find_by_autors(int page, int limit, string search)
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
            List<Magazine> items = new List<Magazine>();
            int index = (page - 1) * limit;
            for (int i = index; i < page * limit; i++)
            {
                AuthorMap map = list.ElementAtOrDefault(i);
                if (map != null)
                {
                    items.Add(service.FindById(map.material_id));
                }
            }
            return items;
        }

        [Route("catalogs/page/{page}/limit/{limit}")]
        public IEnumerable<MagazineCatalog> GetCatalogs(int page, int limit)
        {
            return service_catalogs.Where(page, limit, (o) =>
            {
                return o.enabled == true;
            }, o => o.created);
        }

        [Route("catalogs/{id}")]
        public IEnumerable<Magazine> GetCatalogs(string id)
        {
            return service.get_desc(o => o.catalog_id == id, o => o.created);
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