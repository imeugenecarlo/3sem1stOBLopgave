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
    public class BeersRepositoryTests
    {
        private BeersRepository _beerlist;
        private readonly Beer _badbeer = new() { Name = "Royal Classic", Abv = -3 };

        [TestInitialize]
        public void Init()
        {
            _beerlist = new BeersRepository();
            _beerlist.Add(new() { Name="Heineken", Abv=5});
            _beerlist.Add(new() { Name="Heineken light", Abv=3});
            _beerlist.Add(new() { Name = "Budlight", Abv = 4 });
            _beerlist.Add(new() { Name="Guiness", Abv=4});
            _beerlist.Add(new() { Name = "Fayston Maple", Abv = 18 });
        }

        [TestMethod()]
        public void GetTest()
        {
            List<Beer> beers = _beerlist.Get();
            Assert.AreEqual(5, beers.Count());
            Assert.AreEqual(beers.First().Name,"Heineken");

            //filter test
            List<Beer> filterbeers = _beerlist.Get(nameinclude: "Heineken");
            Assert.AreEqual(2, filterbeers.Count());
            Assert.AreEqual(filterbeers.First().Name, "Heineken");

            List<Beer> filterbeersabv = _beerlist.Get(filterabv: 4);
            Assert.AreEqual(2,filterbeersabv.Count());
            Assert.AreEqual(filterbeersabv.First().Abv,4);

            //sortering test
            List<Beer> sortBeersname = _beerlist.Get(sortby: "name");
            Assert.AreEqual(sortBeersname.First().Name, "Budlight");


            List<Beer> sortbeerAbv = _beerlist.Get(sortby: "abv");
            Assert.AreEqual(sortbeerAbv.First().Abv, 3);
        }
        [TestMethod()]
        public void GetIdTest()
        {
            Assert.IsNotNull( _beerlist.GetId(1) );
            Assert.IsNull(_beerlist.GetId(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Beer b = _beerlist.Add(new Beer { Name = "TestAdd", Abv = 34 });
            //adding actor
            Assert.IsTrue(b.Id >= 0);
            List<Beer> beers = _beerlist.Get();
            Assert.AreEqual(6, beers.Count());
            //testing if exceptions work
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _beerlist.Add(_badbeer));


        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNull( _beerlist.Delete(113));
            Assert.AreEqual(1, _beerlist.Delete(1)?.Id);
            Assert.AreEqual(4, _beerlist.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(5, _beerlist.Get().Count());
            Beer b = new Beer { Name = "Test", Abv = 35 };
            Assert.IsNull(_beerlist.Update(100,b));
            Assert.AreEqual(1, _beerlist.Update(1, b)?.Id);
            Assert.AreEqual(5, _beerlist.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _beerlist.Update(1,_badbeer));
        }
    }
}