// See https://aka.ms/new-console-template for more informationConsole.WriteLine("Hello, Tap!");
Console.WriteLine("Specify .csv with Traveled Data (Distance Traveled, Traveled Unit, and Cost Per Distance Traveled)");var csvPath = Console.ReadLine();
Tap.Interfaces.IGetData dataProcessor = new Tap.UI.GetData();Tap.Interfaces.IManageDriver driverManager = new Tap.UI.ManageDrivers();Tap.Interfaces.ICalculateFare fareCalculator = new Tap.MiddleWare.FareCalculator();
var data = dataProcessor.ProcessData(csvPath);Console.WriteLine("Inputs are captured from: " + csvPath);Console.WriteLine("Total records for traveled Data: " + data.Count);

Console.WriteLine("List of operations to be performed: ");Console.WriteLine("  1. Register Driver.");Console.WriteLine("  2. Delete Driver.");Console.WriteLine("  3. Update Driver.");Console.WriteLine("  4. Show Drivers.");Console.WriteLine("  5. Get cheapest Fare (with Driver).");Console.WriteLine("  6. Show all Fares (with Driver).");Console.WriteLine("  7. Exit.");
bool isContinue = true;while (isContinue){    int i = 0;    bool isValid = Int32.TryParse(Console.ReadLine(), out i);    if (!isValid)        i = 0;    switch (i)    {        // Register        case 1:            var profileToRegister = dataProcessor.GetDriverData();            bool added = driverManager.Register(profileToRegister);            if (added)                fareCalculator.Calculate(profileToRegister, data);            break;
        // Delete        
case 2:            Console.WriteLine("***** Enter driver Name: ");            bool deleted = driverManager.Delete(Console.ReadLine());            if (deleted)                fareCalculator.Calculate(driverManager.GetDeleted(), data);            break;
        // Update        
case 3:            var profileToUpdate = dataProcessor.GetDriverData();            bool updated = driverManager.Update(profileToUpdate);            if (updated)                fareCalculator.Calculate(profileToUpdate, data);            break;
        // Show Drivers        
case 4:            var allDrivers = driverManager.ShowAll();            dataProcessor.PrintData(allDrivers);            break;
        // Get Fare        
case 5:            var cheaper = fareCalculator.GetCheapest();            Console.WriteLine("Cheaper fare is: " + cheaper.Fare + " for " + cheaper.DriverName);            break;
        // Show Fares        
case 6:            var allFares = fareCalculator.ShowAll();            dataProcessor.PrintFares(allFares);            break;
        case 7:            isContinue = false;            break;
        default:            Console.WriteLine("Invalid input. Enter again: ");            break;    }    Console.WriteLine("Enter operation no (1. Add, 2. Delete, 3. Update, 4. Show, 5. Get Fare, 6. All fares) OR 7 to exit: ");}