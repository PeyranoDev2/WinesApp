using Common.Enums;
using Common.Exceptions;
using Common.Extensions;
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
            string NormalizeWineProperty(string input) => input.Trim().Replace(" ", "_");

            string normalizedVariety = NormalizeWineProperty(wineForCreateDTO.Variety);
            string normalizedRegion = NormalizeWineProperty(wineForCreateDTO.Region);

            if (!Enum.TryParse<WineVarietyEnum>(normalizedVariety, true, out var wineVarietyEnum))
                throw new InvalidWineVarietyException("Invalid wine variety provided.");

            if (!Enum.TryParse<WineRegionEnum>(normalizedRegion, true, out var wineRegionEnum))
                throw new InvalidWineRegionException("Invalid wine region provided.");

            if (_wineRepository.WineExists(wineForCreateDTO.Name, wineVarietyEnum, wineForCreateDTO.Year, wineRegionEnum))
                throw new WineAlreadyExistsException("This wine already exists.");

            // Crear un nuevo objeto Wine
            Wine wine = new Wine()
            {
                Name = wineForCreateDTO.Name,
                Variety = wineVarietyEnum,
                Year = wineForCreateDTO.Year,
                Region = wineRegionEnum,
                Stock = wineForCreateDTO.Stock,
                CreatedAt = DateTime.UtcNow,
            };

            _wineRepository.AddWine(wine);
            return wine.Id;
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _wineRepository.GetAllWinesStock();
        }

        public IEnumerable<WineForResponseDTO> Get()
        {
            var wines = _wineRepository.GetAll(); 

            return wines.Select(w => new WineForResponseDTO
            {
                Id = w.Id,
                Name = w.Name,
                Variety = ((WineVarietyEnum)w.Variety).ToFriendlyString(), 
                Region = ((WineRegionEnum)w.Region).ToFriendlyString(),   
                Year = w.Year,
                Stock = w.Stock
            }).ToList();
        }

        public WineForResponseDTO Get(int id)
        {
            var wine = _wineRepository.GetById(id);

            if (wine == null)
            {
                throw new NotFoundException("Wine not found."); 
            }

            var wineResponse = new WineForResponseDTO
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = ((WineVarietyEnum)wine.Variety).ToFriendlyString(), 
                Region = ((WineRegionEnum)wine.Region).ToFriendlyString(),     
                Year = wine.Year,
                Stock = wine.Stock
            };

            return wineResponse; // Retorna el DTO
        }

        public void UpdateWineStock(int wineId, int newStock)
        {
            var wine = _wineRepository.GetById(wineId);
            if (wine == null)
            {
                throw new KeyNotFoundException("Wine not found.");
            }

            wine.Stock = newStock;

            _wineRepository.Update(wine);
        }

        public IEnumerable<Wine> GetWinesByVariety(string variety)
        {
            if (!Enum.TryParse<WineVarietyEnum>(variety.Trim().Replace(" ", ""), true, out var wineVarietyEnum))
            {
                throw new InvalidWineVarietyException("Invalid wine variety provided.");
            }

            return _wineRepository.GetByVariety(wineVarietyEnum);
        }

    }
}