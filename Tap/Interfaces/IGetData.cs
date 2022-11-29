using Tap.Models;

namespace Tap.Interfaces
{
    public interface IGetData
    {
        List<TraveledData> ProcessData(string csvPath);

        DriverProfile GetDriverData();

        void PrintData(List<DriverProfile> drivers);

        void PrintFares(List<FareDetail> fares);
    }
}