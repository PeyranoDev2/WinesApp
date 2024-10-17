using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class WineForCreateDTO
    {
       
        public required string Name { get; set; } 
        public required string Variety { get; set; }
        public required int Year { get; set; }
        public required string Region { get; set; }
        public int Stock { get; set; } = 0;
    }
}