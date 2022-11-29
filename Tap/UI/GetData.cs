using Tap.Models;
using Tap.Interfaces;
namespace Tap.UI
{
    public class GetData : IGetData
    {
        public List<TraveledData> ProcessData(string csvPath) 
        { 
            return File.ReadAllLines(csvPath).Select(line => FromCsv(line)).ToList(); 
        }
        public DriverProfile GetDriverData()
        {
            DriverProfile data = new DriverProfile(); 
            Console.WriteLine("***** Enter driver Name: "); 
            data.Name = Console.ReadLine();
            Console.WriteLine("***** Enter driver Surname: "); 
            data.Surname = Console.ReadLine();
            Console.WriteLine("***** Enter driver Email: "); 
            data.Email = Console.ReadLine();
            Console.WriteLine("***** Enter Vehicle Type: "); 
            data.VehicleType = Console.ReadLine();
            Console.WriteLine("***** Enter driver's Base Fare Price: "); 
            data.BasePrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("***** Enter driver's Base Fare Distance: "); 
            data.BaseDistance = Convert.ToDouble(Console.ReadLine());
            return data;
        }
        public void PrintData(List<DriverProfile> drivers)
        {
            Console.WriteLine(ToFixedString("Name", 20) + " | " + 
                            ToFixedString("Surname", 20) + " | " + 
                            ToFixedString("Email", 20) + " | " + 
                            ToFixedString("VehicleType", 20) + " | " + 
                            ToFixedString("BaseDistance", 20) + " | " + 
                            ToFixedString("BasePrice", 20) + " |");
            foreach (var item in drivers) 
            { 
                Console.WriteLine(ToFixedString(item.Name.ToString(), 20) + " | " + 
                                ToFixedString(item.Surname.ToString(), 20) + " | " + 
                                ToFixedString(item.Email.ToString(), 20) + " | " + 
                                ToFixedString(item.VehicleType.ToString(), 20) + " | " + 
                                ToFixedString(item.BaseDistance.ToString(), 20) + " | " + 
                                ToFixedString(item.BasePrice.ToString(), 20) + " |"); 
            }
        }
        public void PrintFares(List<FareDetail> fares)
        {
            Console.WriteLine(ToFixedString("DriverName", 20) + " | " + 
            ToFixedString("Fare", 15) + " | ");
            foreach (var item in fares) 
            {
                Console.WriteLine(ToFixedString(item.DriverName.ToString(), 20) + " | " + 
                                ToFixedString(item.Fare.ToString(), 15) + " | "); 
            }
        }
        private string ToFixedString(string value, int length, char appendChar = ' ')
        {
            int currlen = value.Length;
            int needed = length == currlen ? 0 : (length - currlen);
            return needed == 0 ? value : (needed > 0 ? value + new string(' ', needed) : 
                new string(new string(value.ToCharArray().Reverse().ToArray())
                            .Substring(needed * -1, value.Length - (needed * -1))
                            .ToCharArray().Reverse().ToArray()));
        }
        private TraveledData FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            TraveledData data = new TraveledData();
            data.Distance = Convert.ToInt32(values[0]);
            data.Unit = Convert.ToDouble(values[1]);
            data.Cost = Convert.ToDouble(values[2]);
            return data;
        }
    }
}