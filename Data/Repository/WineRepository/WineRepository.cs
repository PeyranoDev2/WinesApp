using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WineRepository : IWineRepository
    {

        private readonly WineAppContext _context;

        public WineRepository(WineAppContext context)
        {
            _context = context;
        }
        public List<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }
        public void AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
        }
        public Dictionary<string, int> GetAllWinesStock()
        {
            return _context.Wines.ToDictionary(Wine => Wine.Name, Wine => Wine.Stock);
        }

    }
}