using Tap.Models;

namespace Tap.MiddleWare
{
    public class DriverManager
    {
        private readonly List<DriverProfile> drivers = new List<DriverProfile>(); // holds data

        public bool Add(DriverProfile profile)
        {
            if (!drivers.Any(d => d.Name == profile.Name))
            {
                drivers.Add(profile);
                return true;
            }

            return false;
        }

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

        public bool Modify(DriverProfile newProfile)
        {
            if (drivers.Any(d => d.Name == newProfile.Name))
            {
                DriverProfile profile = drivers.First(d => d.Name == newProfile.Name);
                profile.Surname = newProfile.Surname;
                profile.Email = newProfile.Email;
                profile.BaseDistance = newProfile.BaseDistance;
                profile.BasePrice = newProfile.BasePrice;
                profile.VehicleType = newProfile.VehicleType;

                return true;
            }
            return false;
        }

        public List<DriverProfile> GetAll()
        {
            return drivers;
        }
    }
}