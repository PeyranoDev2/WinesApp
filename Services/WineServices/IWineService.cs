using Common.Models;
using Data.Entities;

namespace Services.WineServices
{
    public interface IWineService
    {
        int AddWine(WineForCreateDTO wineForCreateDTO);
        Dictionary<string, int> GetAllWinesStock();
        void UpdateWineStock(int wineId, int newStock);
        IEnumerable<WineForResponseDTO> Get();
        WineForResponseDTO Get(int id);
        IEnumerable<Wine> GetWinesByVariety(string variety);
    }
}
