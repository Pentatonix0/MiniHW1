using ConsoleApp.Domain.Animals;
using ConsoleApp.Domain.Things;
using ConsoleApp.Domain.Zoo;

namespace ConsoleApp.Services
{
	public class ZooManager
	{
		private readonly Zoo _zoo;

		public ZooManager(Zoo zoo)
		{
			_zoo = zoo;
		}

		// Main Menu
		public void ShowMainMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("=========================================");
			Console.WriteLine("     Welcome to Zoo ERP System");
			Console.WriteLine("=========================================");
			Console.ResetColor();

			Console.WriteLine();
			Console.WriteLine("1. Add New Animal");
			Console.WriteLine("2. Add New Item to Inventory");
			Console.WriteLine("3. Generate Food Report");
			Console.WriteLine("4. Show Petting Zoo Animals");
			Console.WriteLine("5. Conduct Inventory Check");
			Console.WriteLine("6. Exit");
			Console.WriteLine();
			Console.Write("Please select an option (1-6): ");
		}

		// Add Animal to Zoo
		public void AddAnimalToZoo()
		{
			bool continueAddingAnimal = true;
			while (continueAddingAnimal)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("===========================================");
				Console.WriteLine("      Add a New Animal to the Zoo");
				Console.WriteLine("===========================================");
				Console.ResetColor();
				Console.WriteLine();
				Console.WriteLine("Select the type of animal:");
				Console.WriteLine("1. Rabbit");
				Console.WriteLine("2. Tiger");
				Console.WriteLine("3. Monkey");
				Console.WriteLine("4. Wolf");

				string animalType = GetUserInput("Select animal type (1-4): ", input =>
					int.TryParse(input, out int result) && result >= 1 && result <= 4);

				string animalName = GetUserInput("Enter the name of the animal: ",
					input => !string.IsNullOrWhiteSpace(input));

				int dailyFoodAmount = GetValidIntInput("Enter the daily food amount (kg): ",
					value => value is > 0 and <= 100);

				bool isAnimalHealthy = GetUserInput("Is the animal healthy? (yes/no): ",
					input => input.ToLower() == "yes" || input.ToLower() == "no").ToLower() == "yes";

				Animal newAnimal = CreateAnimal(animalType, animalName, dailyFoodAmount, isAnimalHealthy);

				if (_zoo.TryAddAnimal(newAnimal))
				{
					continueAddingAnimal = false;
					Console.WriteLine("\nAnimal successfully added to the zoo!");
				}
				else
				{
					if (GetUserInput("\nWould you like to try adding the animal again? (yes/no): ",
						input => input.ToLower() == "yes" || input.ToLower() == "no").ToLower() != "yes")
					{
						continueAddingAnimal = false;
					}
					Console.Clear();
				}
			}
		}

		// Add Item to Inventory
		public void AddItemToInventory()
		{
			bool continueAddingItem = true;
			while (continueAddingItem)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("===========================================");
				Console.WriteLine("    Add a New Item to the Inventory");
				Console.WriteLine("===========================================");
				Console.ResetColor();
				Console.WriteLine();
				Console.WriteLine("Choose the type of item:");
				Console.WriteLine("1. Table");
				Console.WriteLine("2. Computer");

				string itemType = GetUserInput("Select item type (1-2): ",
					input => int.TryParse(input, out int result) && result >= 1 && result <= 2);

				string itemName = GetUserInput("Enter item name: ",
					input => !string.IsNullOrWhiteSpace(input));

				Thing newThing = CreateInventoryItem(itemType, itemName);

				if (_zoo.TryAddThing(newThing))
				{
					continueAddingItem = false;
					Console.WriteLine("\nItem successfully added to the inventory!");
				}
				else
				{
					if (GetUserInput("\nDo you want to try adding the item again? (yes/no): ",
						input => input.ToLower() == "yes" || input.ToLower() == "no").ToLower() != "yes")
					{
						continueAddingItem = false;
					}
					Console.Clear();
				}
			}
		}

		// Create Animal
		public Animal CreateAnimal(string animalType, string name, int food, bool isHealthy)
		{
			if (animalType == "1")
			{
				return new Rabbit
				{
					Name = name,
					Food = food,
					IsHealthy = isHealthy,
					Kindness = GetValidIntInput("Enter kindness level (1-10): ",
						  value => value >= 1 && value <= 10)
				};
			}
			else if (animalType == "2")
			{
				return new Tiger
				{
					Name = name,
					Food = food,
					IsHealthy = isHealthy
				};
			}
			else if (animalType == "3")
			{
				return new Monkey
				{
					Name = name,
					Food = food,
					IsHealthy = isHealthy,
					Kindness = GetValidIntInput("Enter kindness level (1-10): ",
						  value => value >= 1 && value <= 10)
				};
			}
			else if (animalType == "4")
			{
				return new Wolf
				{
					Name = name,
					Food = food,
					IsHealthy = isHealthy
				};
			}
			else
			{
				throw new ArgumentException("Invalid animal type selection.");
			}
		}

		// Create Inventory Item
		public Thing CreateInventoryItem(string itemType, string name)
		{
			if (itemType == "1")
			{
				return new Table { Name = name };
			}
			else if (itemType == "2")
			{
				return new Computer { Name = name };
			}
			else
			{
				throw new ArgumentException("Invalid item type selection.");
			}
		}

		// Get User Input with validation
		private static string GetUserInput(string prompt, Func<string, bool> inputValidator)
		{
			string userInput;
			do
			{
				Console.Write(prompt);
				userInput = Console.ReadLine();
				if (!inputValidator(userInput))
				{
					Console.WriteLine("INVALID INPUT. Please try again.");
				}
			} while (!inputValidator(userInput));
			return userInput;
		}

		// Get Valid Integer Input with validation
		private static int GetValidIntInput(string prompt, Func<int, bool> valueValidator)
		{
			while (true)
			{
				Console.Write(prompt);
				if (int.TryParse(Console.ReadLine(), out int result) && valueValidator(result))
				{
					return result;
				}
				Console.WriteLine("INVALID INPUT. Please enter a valid number.");
			}
		}
	}
}
