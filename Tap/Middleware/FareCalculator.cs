using Tap.Models;
using Tap.Interfaces;
namespace Tap.MiddleWare{ 
    public class FareCalculator : ICalculateFare 
    { 
        private readonly List<FareDetail> allFares = new List<FareDetail>(); // holds data.
        
        /// <summary>
        /// Calculates fare for all traveled data, for given driver
        /// </summary>
        /// <param name="profile">Driver profile considered for fare calculation</param>
        /// <param name="data">Traveled data provided by user</param>
        /// <returns>Calculated Fare details, along with driver profile</returns>
        public FareDetail Calculate(DriverProfile profile, List<TraveledData> data) 
        {  
            var fare = new FareDetail();  
            data.ForEach(d =>  
            {  
                fare.DriverName = profile.Name;  
                var distanceTraveled = d.Distance - profile.BaseDistance;  
                if (distanceTraveled < 0)   
                    fare.Fare = profile.BasePrice;  
                else  
                {   
                    var units = distanceTraveled / d.Unit;   
                    fare.Fare = profile.BasePrice + (units * d.Cost);  
                }  
                allFares.Add(fare);  
            });
            return fare; 
        }

        /// <summary>
        /// Gets the cheapest fare 
        /// </summary>
        /// <returns>fare details</returns>
        public FareDetail GetCheapest() 
        {  
            return allFares.First(a => a.Fare == allFares.Min(f => f.Fare)); 
        }
        
        /// <summary>
        /// Shows all fare calculations
        /// </summary>
        /// <returns>List of fares for all drivers</returns>
        public List<FareDetail> ShowAll() 
        {  
            return allFares; 
        } 
    }
}
