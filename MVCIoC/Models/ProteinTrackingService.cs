using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIoC.Models
{
    public class ProteinTrackingService : IProteinTrackingService
    {
        private ProteinRepository repository = new ProteinRepository();
        public int Total { get; set; }
        public void AddProtein(int proteinGrams)
        {
            Total += proteinGrams;
        }
    }
}