using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Model
{
    public interface IStewardRepository
    {
        Steward GetSteward(string firsTName,string lastName);
    }
}
