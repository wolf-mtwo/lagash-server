﻿using System;
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
using Wolf.Lagash.Interfaces.helper.ejemplar;
using Wolf.Lagash.Entities.helper.ejemplar;
using Wolf.Lagash.Services.helper.ejemplar;
using LagashServer.Controllers.helpers;

namespace LagashServer.Controllers.v1.helper.ejemplar
{
    [Authorize]
    [RoutePrefix("v1/book/ejemplares")]
    public class BookEjemplaresController : ApiController
    {
        private IBookEjemplarService service = new BookEjemplarService(new LagashContext());

        [Route("")]
        public IEnumerable<BookEjemplar> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(BookEjemplar item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
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
        public IHttpActionResult Get(String id)
        {
            BookEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(String id)
        {
            BookEjemplar item = service.FindById(id);
            if (item == null) {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(String id, BookEjemplar item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != item._id) {
                return new LagashActionResult("should provide a valid _id");
            }
            service.Update(item);
            try {
                service.Commit();
            } catch (DbUpdateConcurrencyException) {
                if (!service.exists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return Ok(item);
        }

        [Route("page/{page}/limit/{limit}")]
        public IEnumerable<BookEjemplar> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.inventory);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<BookEjemplar> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.inventory.ToString().Contains(search) || o._id.Contains(search);
            }, o => o.inventory);
        }

        [Route("size")]
        public Size GetSize()
        {
            return new Size()
            {
                total = service.Count()
            };
        }

        [Route("next")]
        public Ejemplar GetNext()
        {
            return service.next();
        }

        [Route("select")]
        public IEnumerable<BookEjemplar> GetSelect(int start, int end)
        {
            return service.select(start, end);
        }
    }
}