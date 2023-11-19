using LuggageLocate.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageLocate.DAL.Interfaces
{
    public interface IFakeStorage
    {
        public Location GetLocation(string ownerId);

        public Luggage GetLuggage(Guid id);
    }
}
