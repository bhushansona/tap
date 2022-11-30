using Tap.Models;
using Tap.Interfaces;
using Tap.MiddleWare;

namespace Tap.UI
{
    public class GetData : IGetData
    {
        IManageDriver driverManager = new ManageDrivers();
        ICalculateFare fareCalculator = new FareCalculator();

        /// <summary>
        /// Processed .csv data provided by user
        /// </summary>
        /// <param name="csvPath">.csv file full path</param>
        /// <returns>List of traveled data captured from file</returns>
        public List<TraveledData> ProcessData(string csvPath) 
        { 
            return File.ReadAllLines(csvPath).Select(line => FromCsv(line)).ToList(); 
        }
        
        /// <summary>
        /// Requets operation to be perform and completes it.
        /// </summary>
        /// <param name="data">Traveled data</param>
        public void PerformOperation(List<Tap.Models.TraveledData> data)
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.Write(" ******** Enter operation no: ");
                int i = 0;
                bool isValid = Int32.TryParse(Console.ReadLine(), out i);
                if (!isValid)
                    i = 0;
                switch (i)
                {
                    // Register 
                    case 1:
                        var profileToRegister = GetDriverData();
                        bool added = driverManager.Register(profileToRegister);
                        if (added)
                        {
                            Console.WriteLine($"Driver {profileToRegister.Name} registered successfully.");
                            fareCalculator.Calculate(profileToRegister, data);
                        }
                        else
                        {
                            Console.WriteLine("Failed to register driver!!");
                        }
                        break;
                    // Delete 
                    case 2:
                        Console.Write("  Enter driver Name to delete: ");
                        bool deleted = driverManager.Delete(Console.ReadLine());
                        if (deleted)
                        {
                            DriverProfile profileDeleted = driverManager.GetDeleted();
                            Console.WriteLine($"Driver {profileDeleted.Name} deleted successfully.");
                            fareCalculator.Calculate(profileDeleted, data);
                        }
                        else
                        {
                            Console.WriteLine("Failed to remove driver!!");
                        }
                        break;
                    // Update 
                    case 3:
                        var profileToUpdate = GetDriverData();
                        bool updated = driverManager.Update(profileToUpdate);
                        if (updated)
                        {
                            Console.WriteLine($"Driver {profileToUpdate.Name} updated successfully.");
                            fareCalculator.Calculate(profileToUpdate, data);
                        }
                        else
                        {
                            Console.WriteLine("Failed to update driver profile!! Driver is mandatory.");
                        }
                        break;
                    // Show Drivers 
                    case 4:
                        var allDrivers = driverManager.ShowAll();
                        PrintData(allDrivers);
                        break;
                    // Get Fare 
                    case 5:
                        var cheaper = fareCalculator.GetCheapest();
                        Console.WriteLine("Cheaper fare is: " + cheaper.Fare + " with " + cheaper.DriverName);
                        break;
                    // Show Fares 
                    case 6:
                        var allFares = fareCalculator.ShowAll();
                        PrintFares(allFares);
                        break;
                    case 7:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Enter again. ");
                        break;
                }
                Console.WriteLine("Select operation (1. Add, 2. Delete, 3. Update, 4. Show drivers, 5. Lowest Fare, 6. All fares) OR 7 to exit: ");
            }
        }

        /// <summary>
        /// Gets driver data from user via console.
        /// </summary>
        /// <returns>Driver profile as per provided details</returns>
        public DriverProfile GetDriverData()
        {
            DriverProfile data = new DriverProfile(); 
            Console.Write("  Enter driver Name: "); 
            data.Name = Console.ReadLine();
            Console.Write("  Enter driver Surname: "); 
            data.Surname = Console.ReadLine();
            Console.Write("  Enter driver Email: "); 
            data.Email = Console.ReadLine();
            Console.Write("  Enter Vehicle Type: "); 
            data.VehicleType = Console.ReadLine();
            Console.Write("  Enter driver's Base Fare Price: "); 
            data.BasePrice = ParseNum(Console.ReadLine());
            Console.Write("  Enter driver's Base Fare Distance: "); 
            data.BaseDistance = ParseNum(Console.ReadLine());
            return data;
        }
        
        private double ParseNum(string str)
        {
            double number;
            if(double.TryParse(str,out number))
                return number > 0 ? number : 0;
            return 0;
        }

        /// <summary>
        /// Prints driver data on application console
        /// </summary>
        /// <param name="drivers">Drivers data to be printed</param>
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
        
        /// <summary>
        /// Prints fare details on console. Considering string length limitation on console, data is printed with limited characters.
        /// </summary>
        /// <param name="fares">Fare's data to be printed on console.</param>
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