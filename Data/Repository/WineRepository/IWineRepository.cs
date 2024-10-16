using Data.Entities;

namespace Data.Repository
{
    public interface IWineRepository
    {
        void AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
        List<Wine> GetWines();
    }
}