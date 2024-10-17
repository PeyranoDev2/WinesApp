using Common.Enums;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public bool WineExists(string name, WineVarietyEnum variety, int year, WineRegionEnum region)
        {
            return _context.Wines.Any(w => w.Name == name &&
                                           w.Variety == variety &&
                                           w.Year == year &&
                                           w.Region == region);
        }
        public Wine? GetById(int wineId)
        {
            return _context.Wines.Find(wineId);
        }

        public IEnumerable<Wine> GetAll()
        {
            return _context.Wines.ToList();
        }

            public void Update(Wine wine)
        {
            _context.Entry(wine).State = EntityState.Modified;
            _context.SaveChanges(); 
        }

        public IEnumerable<Wine> GetByVariety(WineVarietyEnum variety)
        {
            return _context.Wines.Where(w => w.Variety == variety).ToList();
        }
    }
}
