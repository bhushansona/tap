using Tap.Models;

namespace Tap.Interfaces
{
    public interface IManageDriver
    {
        bool Register(DriverProfile profile);

        bool Delete(string driverName);

        bool Update(DriverProfile profile);

        DriverProfile GetDeleted();
        
        List<DriverProfile> ShowAll();
    }
}