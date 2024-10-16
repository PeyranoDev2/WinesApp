using Common.Models;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.WineServices
{
    public class WineService : IWineService
    {
        public readonly IWineRepository _wineRepository;
        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }


        public int AddWine(WineForCreateDTO wineForCreateDTO)
        {
            // Verificar si el vino ya existe
            var existingWine = _wineRepository.GetWines()
                .FirstOrDefault(w => w.Name == wineForCreateDTO.Name &&
                                     w.Variety == wineForCreateDTO.Variety &&
                                     w.Year == wineForCreateDTO.Year);

            if (existingWine != null)
            {
                throw new InvalidOperationException("This wine already exists");
            }

            // Crear un nuevo objeto Wine
            Wine wine = new Wine()
            {
                Name = wineForCreateDTO.Name,
                Variety = wineForCreateDTO.Variety,
                Year = wineForCreateDTO.Year,
                Region = wineForCreateDTO.Region,
                Stock = wineForCreateDTO.Stock,
                CreatedAt = DateTime.UtcNow,
            };

            // Agregar el vino al repositorio
            _wineRepository.AddWine(wine);
            return wine.Id; // El ID ya estará establecido por la base de datos
        }

        public Dictionary<string, int> GetAllWinesStock()
                {
                    return _wineRepository.GetAllWinesStock();
                }
        }
}