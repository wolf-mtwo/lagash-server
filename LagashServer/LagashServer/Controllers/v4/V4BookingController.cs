using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Wolf.Lagash.Services;
using LagashServer.helper;
using Wolf.Lagash.Entities.books;
using LagashServer.Controllers.helpers;
using Wolf.Lagash.Entities.booking;
using Wolf.Lagash.Entities.thesis;
using Wolf.Lagash.Entities.magazine;
using Wolf.Lagash.Entities.newspaper;
using Wolf.Lagash.Services.booking;
using Wolf.Lagash.Services.books;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Services.newspaper;
using Wolf.Lagash.Services.thesis;
using Wolf.Lagash.Interfaces.booking;
using Wolf.Lagash.Interfaces.books;
using Wolf.Lagash.Interfaces.thesis;
using Wolf.Lagash.Interfaces.newspaper;
using Wolf.Lagash.Interfaces.magazine;

namespace LagashServer.Controllers.v4
{
    [RoutePrefix("v4/booking")]
    public class V4BookingController : ApiController
    {
        private IBookingService service = new BookingService(new LagashContext());
        private IBookEjemplarService service_books = new BookEjemplarService(new LagashContext());
        private IThesisEjemplarService service_thesis = new ThesisEjemplarService(new LagashContext());
        private IMagazineEjemplarService service_magazines = new MagazineEjemplarService(new LagashContext());
        private INewspaperEjemplarService service_newpapes = new NewspaperEjemplarService(new LagashContext());

        [Route("")]
        public IEnumerable<Booking> Get()
        {
            return service.GetAll();
        }

        [Route("")]
        public IHttpActionResult Post(Booking item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Loan loan = new Loan()
                {
                    material_id = item.material_id,
                    state = item.state,
                    ejemplar_id = item.ejemplar_id,
                    type = item.type
                };
                this.loan_material(loan);
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
            Booking item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(String id)
        {
            Booking item = service.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            Loan loan = new Loan()
            {
                material_id = item.material_id,
                state = "STORED",
                ejemplar_id = item.ejemplar_id,
                type = item.type
            };
            this.loan_material(loan);
            service.Delete(item);
            service.Commit();
            return Ok(item);
        }

        [Route("{id}")]
        public IHttpActionResult Put(String id, Booking item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item._id)
            {
                return new LagashActionResult("should provide a valid _id");
            }
            try
            {
                Booking ejemplar = service.FindOne(o => o.code == item.code);
                if (ejemplar != null && ejemplar._id != id)
                {
                    return new LagashActionResult("El codigo ya esta registrado");
                }
                service.discart(ejemplar);
                service.Update(item);
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
        public IEnumerable<Booking> Get(int page, int limit)
        {
            return service.GetPage(page, limit, o => o.created);
        }

        [Route("page/{page}/limit/{limit}/search")]
        public IEnumerable<Booking> GetFind(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.name.ToLower().Contains(search.ToLower()) || o.code.Contains(search.ToLower());
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

        [Route("page/{page}/limit/{limit}/loans")]
        public IEnumerable<Booking> GetLoans(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.name.ToLower().Contains(search.ToLower()) && o.state.Equals("BOOKED");
            }, o => o.created);
        }
        
        [Route("page/{page}/limit/{limit}/returns")]
        public IEnumerable<Booking> GetReturns(int page, int limit, string search)
        {
            if (search == null) search = "";
            return service.Where(page, limit, (o) => {
                return o.name.ToLower().Contains(search.ToLower()) && o.state.Equals("BORROWED");
            }, o => o.created);
        }

        [Route("loan")]
        public IHttpActionResult PostBorrow(Loan loan)
        {
            try
            {                
                loan_material(loan);
                Booking booking = service.FindById(loan._id);
                booking.state = loan.state;
                booking.created = DateTime.Now;
                service.Update(booking);
                service.Commit();
            }
            catch (Exception e)
            {
                return new LagashActionResult(e.Message);
            }
            return Ok(loan);
        }

        void loan_material(Loan loan)
        {
            string state = loan.state;
            if (loan.state.Equals("RESTORED")) {
                state = "STORED";
            }
            switch (loan.type)
            {
                case "BOOK":
                    BookEjemplar book_ejemplar = service_books.FindById(loan.ejemplar_id);
                    book_ejemplar.state = state;
                    service_books.Update(book_ejemplar);
                    service_books.Commit();
                    break;
                case "THESIS":
                    ThesisEjemplar thesis_ejemplar = service_thesis.FindById(loan.ejemplar_id);
                    thesis_ejemplar.state = state;
                    service_thesis.Update(thesis_ejemplar);
                    service_thesis.Commit();
                    break;
                case "MAGAZINE":
                    MagazineEjemplar magazine_ejemplar = service_magazines.FindById(loan.ejemplar_id);
                    magazine_ejemplar.state = state;
                    service_magazines.Update(magazine_ejemplar);
                    service_magazines.Commit();
                    break;
                case "NEWSPAPER":
                    NewspaperEjemplar newspaper_ejemplar = service_newpapes.FindById(loan.ejemplar_id);
                    newspaper_ejemplar.state = state;
                    service_newpapes.Update(newspaper_ejemplar);
                    service_newpapes.Commit();
                    break;

                default:
                    Console.WriteLine("default case");
                    break;
            }
        }
    }
}