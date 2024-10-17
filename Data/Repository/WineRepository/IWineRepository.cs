using Common.Enums;
using Data.Entities;

namespace Data.Repository
{
    public interface IWineRepository
    {
        void AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
        List<Wine> GetWines();
        bool WineExists(string name, WineVarietyEnum variety, int year, WineRegionEnum region);
        void Update(Wine wine);
        Wine? GetById(int wineId);
        IEnumerable<Wine> GetAll();
        IEnumerable<Wine> GetByVariety(WineVarietyEnum variety);
    }
}