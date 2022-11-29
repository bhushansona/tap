using Tap.Interfaces;
using Tap.Models;
using Tap.MiddleWare;

namespace Tap.UI
{
    public class ManageDrivers : IManageDriver
    {
        public DriverManager manager = new DriverManager();
        public DriverProfile deletedProfile = new DriverProfile();
        public bool Register(DriverProfile profile)
        {
            return manager.Add(profile);
        }

        public bool Delete(string driverName)
        {
            DriverProfile profile;
            bool deleted = manager.Remove(driverName, out profile);
            deletedProfile = deleted ? profile : null;
            return deleted;
        }

        public DriverProfile GetDeleted()
        {
            return deletedProfile;
        }
        
        public bool Update(DriverProfile profile)
        {
            return manager.Modify(profile);
        }

        public List<DriverProfile> ShowAll()
        {
            return manager.GetAll();
        }
    }
}