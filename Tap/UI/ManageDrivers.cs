using Tap.Interfaces;
using Tap.Models;
using Tap.MiddleWare;

namespace Tap.UI
{
    public class ManageDrivers : IManageDriver
    {
        public DriverManager manager = new DriverManager();
        public DriverProfile deletedProfile = new DriverProfile();
        
        /// <summary>
        /// Registers new driver profile in system
        /// </summary>
        /// <param name="profile">Driver data</param>
        /// <returns>True, is registered successfully.</returns>
        public bool Register(DriverProfile profile)
        {
            return manager.Add(profile);
        }

        /// <summary>
        /// Removes Driver registered.
        /// </summary>
        /// <param name="driverName">Driver name to be removed</param>
        /// <returns>True, if deletion succeeded</returns>
        public bool Delete(string driverName)
        {
            DriverProfile profile;
            bool deleted = manager.Remove(driverName, out profile);
            deletedProfile = deleted ? profile : null;
            return deleted;
        }

        /// <summary>
        /// Get the details of profile deleted
        /// </summary>
        /// <returns>Driver profile</returns>
        public DriverProfile GetDeleted()
        {
            return deletedProfile;
        }
        
        /// <summary>
        /// Update details of registered driver. Note that driver name will be matched to identify driver.
        /// </summary>
        /// <param name="profile">Driver details to be updated.</param>
        /// <returns>Updated driver profile</returns>
        public bool Update(DriverProfile profile)
        {
            return manager.Modify(profile);
        }

        /// <summary>
        /// Show all drivers registered.
        /// </summary>
        /// <returns>List of drivers</returns>
        public List<DriverProfile> ShowAll()
        {
            return manager.GetAll();
        }
    }
}