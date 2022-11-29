using Tap.Models;

namespace Tap.Interfaces
{
    public interface ICalculateFare
    {
        FareDetail Calculate(DriverProfile profile, List<TraveledData> data);

        FareDetail GetCheapest();

        List<FareDetail> ShowAll();
    }
}