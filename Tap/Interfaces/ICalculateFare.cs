using Tap.Models;

namespace Tap.Interfaces
{
    /// <summary>
    /// Interface to calculate fare
    /// </summary>
    public interface ICalculateFare
    {
        FareDetail Calculate(DriverProfile profile, List<TraveledData> data);

        FareDetail GetCheapest();

        List<FareDetail> ShowAll();
    }
}