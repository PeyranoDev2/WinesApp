using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InvalidWineVarietyException : Exception
    {
        public InvalidWineVarietyException(string message) : base(message) { }
    }

    public class InvalidWineRegionException : Exception
    {
        public InvalidWineRegionException(string message) : base(message) { }
    }

    public class WineAlreadyExistsException : Exception
    {
        public WineAlreadyExistsException(string message) : base(message) { }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
