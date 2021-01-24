using System;
using System.Collections.Generic;
using RaceSimulationWPF.Model;

namespace RaceSimulationWPF.Helpers
{
    [Serializable]
    public class ExportFormat
    {
        public List<Person> StartList { get; set; }
        public List<RaceResult> RaceResults { get; set; }
        public ExportFormat() { }
    }
}
