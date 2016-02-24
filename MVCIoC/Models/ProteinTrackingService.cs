namespace MVCIoC.Models
{
    public class ProteinTrackingService : IProteinTrackingService
    {
        //You would create a Repository (that hooks up to a database or whatever here) and use that
        //private ProteinRepository repository = new ProteinRepository();

        public int Total { get; set; }
        public void AddProtein(int proteinGrams)
        {
            Total += proteinGrams;
        }
    }
}