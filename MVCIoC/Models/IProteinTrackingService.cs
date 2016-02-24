namespace MVCIoC.Models
{
    public interface IProteinTrackingService
    {
        int Total { get; set; }
        void AddProtein(int proteinGrams);
    }
}