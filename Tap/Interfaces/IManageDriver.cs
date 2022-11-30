using Tap.Models;

namespace Tap.Interfaces
{
    /// <summary>
    /// Interface used for managing drivers
    /// </summary>
    public interface IManageDriver
    {
        bool Register(DriverProfile profile);

        bool Delete(string driverName);

        bool Update(DriverProfile profile);

        DriverProfile GetDeleted();
        
        List<DriverProfile> ShowAll();
    }
}