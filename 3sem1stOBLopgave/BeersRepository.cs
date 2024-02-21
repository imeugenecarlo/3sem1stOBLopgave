using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem1stOBLopgave
{
    public class BeersRepository
    {
        private readonly List<Beer> _beerslist = new();
        private int _nextid = 0;
        public BeersRepository() 
        {

        }

        public List<Beer> Get(string? nameinclude = null, int? filterabv = null, string? sortby = null) 
        {
            List<Beer> list = new(_beerslist);
            if(nameinclude != null)
            {
                list = list.FindAll(x=> x.Name.StartsWith(nameinclude));
            }
            if(filterabv != null)
            {
                list = list.FindAll(x=>x.Abv ==(filterabv));
            }
            if(sortby != null)
            {
                switch(sortby)
                {
                    case "name":
                        list.Sort((a1,a2) => a1.Name.CompareTo(a2.Name));
                        break;
                    case "abv":
                        list.Sort((a1,a2)=> a1.Abv.CompareTo(a2.Abv)); 
                        break;

                }
            }

            return list;
             
        }

        public Beer? GetId(int id)
        {
            return _beerslist.Find(x => x.Id == id);
        }

        public Beer Add(Beer beer)
        {
            beer.Validate();
            beer.Id = _nextid++;
            _beerslist.Add(beer);
            return beer;
        }

        public Beer Delete(int id)
        {
            Beer? beer = GetId(id);
            if (beer == null)
            {
                return null;
            }
            _beerslist.Remove(beer);
            return beer;
        }

        public Beer? Update(int id, Beer beer)
        {
            beer.Validate();
            Beer? existingbeer = GetId(id);
            if(existingbeer == null)
            {
                return null;
            }
            existingbeer.Name = beer.Name;
            existingbeer.Abv = beer.Abv;
            return existingbeer;
        }

    }
}
