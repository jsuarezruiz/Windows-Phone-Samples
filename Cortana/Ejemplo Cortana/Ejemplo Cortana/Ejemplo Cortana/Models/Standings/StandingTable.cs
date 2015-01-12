using System.Collections.Generic;

namespace Ejemplo_Cortana.Models
{
    public class StandingTable
    {
        public string Season { get; set; }
        public List<StandingList> StandingsLists { get; set; }
    }
}
