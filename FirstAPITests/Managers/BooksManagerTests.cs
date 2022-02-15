using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Managers.Tests
{
    [TestClass()]
    public class BooksManagerTests
    {
        private BooksManager _manager;

        [TestInitialize]
        public void initialize()
        {
            _manager = new BooksManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_manager.GetAll(null, null));

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, _manager.GetAll(null, 800).Count());
            Assert.AreNotEqual(expectedCount, _manager.GetAll(null, 801).Count());
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddBookTest()
        {
            //Assert.Fail();
        }
    }
}