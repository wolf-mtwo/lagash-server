using System;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Entities.helper.reader;
using Wolf.Lagash.Services.helpers.reader;
using Wolf.Lagash.Interfaces.helpers.reader;
using Wolf.Lagash.Services.booking;
using Wolf.Lagash.Interfaces.booking;
using Wolf.Lagash.Entities.booking;
using System.Collections.Generic;

namespace LagashServer.Controllers.v6
{
    [RoutePrefix("v6/readers")]
    public class V6ReaderController : ApiController
    {
        private IReaderService service = new ReaderService(new LagashContext());
        private IBookingService service_booking = new BookingService(new LagashContext());

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

        [Route("ejemplares/{ejemplar_id}")]
        public IHttpActionResult GetReader(String ejemplar_id)
        {
            Booking booking = service_booking.FindOne(
                o => o.ejemplar_id.Equals(ejemplar_id) && !o.state.Equals("RESTORED")
            );

            if (booking == null) {
                return NotFound();
            }

            Reader item = service.FindById(booking.reader_id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}