using Tap.Models;

namespace Tap.MiddleWare
{
    public class DriverManager
    {
        private readonly List<DriverProfile> drivers = new List<DriverProfile>(); // holds data

        /// <summary>
        /// Adds driver to be registered with profile
        /// </summary>
        /// <param name="profile">Driver profile</param>
        /// <returns>True, if added successfully</returns>
        public bool Add(DriverProfile profile)
        {
            if (!drivers.Any(d => d.Name == profile.Name))
            {
                drivers.Add(profile);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes driver, based on his name.
        /// </summary>
        /// <param name="name">Name of driver</param>
        /// <param name="profile">Driver profile, being deleted</param>
        /// <returns>True, if removed successfully.</returns>
        public bool Remove(string name, out DriverProfile profile)
        {
            profile = new DriverProfile();
            if (drivers.Any(d => d.Name == name))
            {
                profile = drivers.First(d => d.Name == name);
                drivers.Remove(profile);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifies driver profile details
        /// </summary>
        /// <param name="newProfile">Updated driver profile</param>
        /// <returns>True, if driver details updated successfully.</returns>
        public bool Modify(DriverProfile newProfile)
        {
            if (drivers.Any(d => d.Name == newProfile.Name))
            {
                DriverProfile profile = drivers.First(d => d.Name == newProfile.Name);
                profile.Surname = string.IsNullOrWhiteSpace(newProfile.Surname)?profile.Surname:newProfile.Surname;
                profile.Email = string.IsNullOrWhiteSpace(newProfile.Email)?profile.Email:newProfile.Email;
                profile.BaseDistance = newProfile.BaseDistance;
                profile.BasePrice = newProfile.BasePrice;
                profile.VehicleType = string.IsNullOrWhiteSpace(newProfile.VehicleType)?profile.VehicleType:newProfile.VehicleType;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Get details of all registered driver.
        /// </summary>
        /// <returns>List of drivers</returns>
        public List<DriverProfile> GetAll()
        {
            return drivers;
        }
    }
}