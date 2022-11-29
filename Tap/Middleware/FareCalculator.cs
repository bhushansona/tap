using Tap.Models;
using Tap.Interfaces;
namespace Tap.MiddleWare{ 
    public class FareCalculator : ICalculateFare 
    { 
        private readonly List<FareDetail> allFares = new List<FareDetail>(); // holds data.
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
        public FareDetail GetCheapest() 
        {  
            return allFares.First(a => a.Fare == allFares.Min(f => f.Fare)); 
        }
        public List<FareDetail> ShowAll() 
        {  
            return allFares; 
        } 
    }
}
