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

namespace LagashServer.Controllers
{
    public class LibrariesController : ApiController
    {
        private ILibrariesService service = new LibrariesService(new LagashContext());

        public IEnumerable<Library> Get()
        {
            return service.GetAll();
        }

        [ResponseType(typeof(Library))]
        public IHttpActionResult Post(Library item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                service.Create(item);
                service.Commit();
            }
            catch (Exception e)
            {
                return new LagashActionResult(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = item._id }, item);
        }

        [ResponseType(typeof(Library))]
        public IHttpActionResult Get(int id)
        {
            Library item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [ResponseType(typeof(Library))]
        public IHttpActionResult Delete(int id)
        {
            Library item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            service.Delete(item);
            service.Commit();

            return Ok(item);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Library item)
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
    }
}