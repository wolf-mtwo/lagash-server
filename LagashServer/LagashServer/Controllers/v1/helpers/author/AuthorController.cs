using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.helper.author;
using Wolf.Lagash.Services.helpers.author;
using Wolf.Lagash.Interfaces.helpers.author;

namespace LagashServer.Controllers.v1.helpers.author
{
    [Authorize]
    [RoutePrefix("v1/authors")]
    public class AuthorController : ApiController
    {
        private IAuthorService service = new AuthorService(new LagashContext());
        private IAuthorMapService service_map = new AuthorMapService(new LagashContext());

        [Route("")]
        public IEnumerable<Author> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(Author item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //Author ejemplar = service.FindOne(o => o.code == item.code);
                //if (ejemplar != null)
                //{
                //    return new LagashActionResult("El codigo de autor ya existe");
                //}
                service.Create(item);
                service.Commit();
            }
            catch (Exception e)
            {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            Author item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            Author item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(string id, Author item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item._id)
            {
                return new LagashActionResult("should provide a valid _id");
            }
            service.Update(item);
            try
            {
                service.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(item);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<Author> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.created);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<Author> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (u) =>
            {
                return u.code.Contains(search) || u.first_name.ToLower().Contains(search.ToLower()) || u.last_name.ToLower().Contains(search.ToLower());
            }, o => o.created);
        }

        [Route("size")]
        public Size GetSize()
        {
            return new Size()
            {
                total = service.Count()
            };
        }

        [Route("find")]
        public IEnumerable<Author> GetFind(string material_id)
        {
            IEnumerable<AuthorMap> items = service_map.get_asc(o => o.material_id == material_id, o => o.created);
            List<Author> result = new List<Author>();
            foreach (var item in items)
            {
                Author author = service.FindById(item.author_id);
                if (author != null)
                {
                    author.map = item;
                    result.Add(author);
                }
            }
            return result;
        }
    }
}