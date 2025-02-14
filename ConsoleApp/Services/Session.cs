using ConsoleApp.Domain.Zoo;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Services
{
	public class Session
	{
		public static void Start()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			// Registering dependencies
			var services = new ServiceCollection();
			services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
			services.AddSingleton<Zoo>();
			services.AddSingleton<NumberGenerator>();
			services.AddSingleton<ZooManager>();
			var serviceProvider = services.BuildServiceProvider();

			// Retrieving services from the container
			var zoo = serviceProvider.GetService<Zoo>();
			var managementService = serviceProvider.GetService<ZooManager>();

			while (true)
			{
				try
				{
					// Displaying the main menu
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("=========================================");
					Console.WriteLine("     Welcome to Zoo ERP System");
					Console.WriteLine("=========================================");
					Console.ResetColor();

					managementService.ShowMainMenu();

					string choice = Console.ReadLine();
					Console.Clear();

					// Processing user's choice
					switch (choice)
					{
						case "1":
							managementService.AddAnimalToZoo();
							break;
						case "2":
							managementService.AddItemToInventory();
							break;
						case "3":
							zoo.DisplayTotalFoodConsumption();
							break;
						case "4":
							zoo.ShowContactZooAnimals();
							break;
						case "5":
							zoo.PerformInventoryCheck();
							break;
						case "6":
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("\nThank you for using the Zoo ERP System!");
							Console.ResetColor();
							return;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("\nINVALID INPUT. Please select a number between 1 and 6.");
							Console.ResetColor();
							break;
					}

					// Waiting for user input to continue
					Console.WriteLine("\nPress any key to continue...");
					Console.ReadKey();
					Console.Clear();
				}
				catch (Exception ex)
				{
					// Handling exceptions with a stylish error message
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"\nERROR: {ex.Message}");
					Console.ResetColor();
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					Console.Clear();
				}
			}
		}
	}
}
