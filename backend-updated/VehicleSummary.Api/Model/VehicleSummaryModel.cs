using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryModel
    {
        public string Name { get; set; }
        public int YearsAvailable { get; set; }

        public VehicleSummaryModel(string name, int yearsAvailable)
        {
            Name = name;
            YearsAvailable = yearsAvailable;
        }

        public string ToString()
        {
            return Name + ", " + YearsAvailable.ToString() + " years";
        }
    }
}
