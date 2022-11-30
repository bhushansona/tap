using Tap.Models;

namespace Tap.Interfaces
{
    /// <summary>
    /// UI Interface to get and process data from user
    /// </summary>
    public interface IGetData
    {
        List<TraveledData> ProcessData(string csvPath);

        void PerformOperation(List<Tap.Models.TraveledData> data);

        DriverProfile GetDriverData();

        void PrintData(List<DriverProfile> drivers);

        void PrintFares(List<FareDetail> fares);
    }
}