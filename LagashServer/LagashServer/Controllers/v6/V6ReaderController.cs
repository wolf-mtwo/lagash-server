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
using Wolf.Lagash.Interfaces.map;
using Wolf.Lagash.Entities.map;
using Wolf.Lagash.Entities.tutor;

namespace LagashServer.Controllers.v6
{
    [RoutePrefix("v6/readers")]
    public class V6ReaderController : ApiController
    {
        private IReaderService service = new ReaderService(new LagashContext());
        
        [Route("")]
        public IHttpActionResult Post(Reader item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Get(String id)
        {
            Reader item = service.FindOne((o) => o.card_id == id);
            if (item == null) {
                return NotFound();
            }
            return Ok(item);
        }
    }
}