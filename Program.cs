// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, Tap user!");
Console.Write("Specify .csv with Traveled Data (Distance Traveled, Traveled Unit, and Cost Per Distance Traveled): ");
var csvPath = Console.ReadLine();

Tap.Interfaces.IGetData dataHandler = new Tap.UI.GetData();
var data = dataHandler.ProcessData(csvPath);
Console.WriteLine("Inputs are captured from: " + csvPath);
Console.WriteLine("Total records for traveled Data: " + data.Count);

Console.WriteLine("List of operations to be performed: ");
Console.WriteLine("  1. Register Driver.");
Console.WriteLine("  2. Delete Driver.");
Console.WriteLine("  3. Update Driver.");
Console.WriteLine("  4. Show Drivers.");
Console.WriteLine("  5. Get cheapest Fare (with Driver).");
Console.WriteLine("  6. Show all Fares (with Driver).");
Console.WriteLine("  7. Exit.");

dataHandler.PerformOperation(data);

