using Common.Models;
using Data.Entities;

namespace Services.WineServices
{
    public interface IWineService
    {
        int AddWine(WineForCreateDTO wineForCreateDTO);
        Dictionary<string, int> GetAllWinesStock();
    }
}
