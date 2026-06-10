using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerbariumLearnApp
{
    class Plant
    {
        public string Id { get; set; }
        public string GerName { get; set; }
        public string LatName { get; set; }
        public string GerFamily { get; set; }
        public string LatFamily { get; set; }
        public DateOnly DiscoveryDate { get; set; }
        public string Location { get; set; }

    public Plant(string id, string gerName, string latName, string gerfamily, string latfamily, DateOnly DiscoverDate, string location)
        {
            this.Id = id;
            this.GerName = gerName;
            this.LatName = latName;
            this.GerFamily = gerfamily;
            this.LatFamily = latfamily;
            this.DiscoveryDate = DiscoverDate;
            this.Location = location;
        }
    }
}
