using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class WineForCreateDTO
    {
        public string Name { get; set; }
        public string Variety { get; set; }
        public int Year { get; set; }
        public string Region { get; set; }
        public int Stock { get; set; }
    }
}