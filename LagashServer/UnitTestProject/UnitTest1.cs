using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wolf.Lagash.Entities.books;
using LagashServer.helper;
using Wolf.Lagash.Entities;
using Wolf.Lagash.Services.books;
using Wolf.Lagash.Services.magazine;
using Wolf.Lagash.Services.thesis;
using Wolf.Lagash.Interfaces.thesis;
using Wolf.Lagash.Interfaces.magazine;
using Wolf.Lagash.Interfaces.books;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBook()
        {
            IBookService service = new BookService(new LagashContext());
            Book item = new Book() {
                title = "book's title",
                enabled = true
            };
            try {
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                Assert.Fail("hubo un problema al crear el libro", e.Message);
            }
        }

        [TestMethod]
        public void CreateThesis()
        {
            IThesisService service = new ThesisService(new LagashContext());
            Thesis item = new Thesis()
            {
                title = "thesis's title",
                enabled = true
            };
            try {
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                Assert.Fail("hubo un problema al crear la tesis", e.Message);
            }
        }

        [TestMethod]
        public void CreateMagazine()
        {
            IMagazineService service = new MagazineService(new LagashContext());
            Magazine item = new Magazine()
            {
                title = "magazine's title",
                enabled = true
            };
            try {
                service.Create(item);
                service.Commit();
            } catch (Exception e) {
                Assert.Fail("hubo un problema al crear la revista", e.Message);
            }
        }
    }
}
