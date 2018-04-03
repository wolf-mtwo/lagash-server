using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wolf.Lagash.Entities.books;
using LagashServer.helper;
using Wolf.Lagash.Services;
using Wolf.Lagash.Interfaces;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IBookService service = new BookService(new LagashContext());
            Book item = new Book();
            item.title = "";
            //book.save
            try
            {
                service.Create(item);
                service.Commit();
            }
            catch (Exception e)
            {
                Assert.Fail("s", e.Message);
            }
        }
    }
}
