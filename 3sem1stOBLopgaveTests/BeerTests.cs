using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3sem1stOBLopgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem1stOBLopgave.Tests
{
    [TestClass()]
    public class BeerTests
    {

        private readonly Beer _beer = new() { Id=1,Name="Heineken",Abv = 5};
        private readonly Beer _beerisnull = new() { Id = 2, Abv = 11 };
        private readonly Beer _emptybeer = new() { Id = 3, Name = "", Abv = 13 };
        private readonly Beer _abvlow = new() { Id = 4, Name ="Heineken Pilsner",  Abv = -1};
        private readonly Beer _abvhigh = new() { Id = 5, Name = "Moonshine", Abv = 89 };

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Heineken 5",_beer.ToString());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            _beer.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => _beerisnull.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => _emptybeer.ValidateName());
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            _beer.ValidateAbv();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _abvlow.ValidateAbv());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _abvhigh.ValidateAbv());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _beer.Validate();
        }
    }
}