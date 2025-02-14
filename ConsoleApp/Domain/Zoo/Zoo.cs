using ConsoleApp.Domain.Animals;
using ConsoleApp.Domain.Things;
using ConsoleApp.Services;

namespace ConsoleApp.Domain.Zoo
{
	public class Zoo
	{
		private List<Animal> _animals = new List<Animal>();
		private List<Thing> _things = new List<Thing>();
		private List<Herbo> _contactAnimals = new List<Herbo>();

		private NumberGenerator _numberGenerator = new NumberGenerator();

		private readonly IVeterinaryClinic Clinic;

		public Zoo(IVeterinaryClinic clinic)
		{
			this.Clinic = clinic;
		}

		// Display the total number of animals in the zoo
		public void DisplayTotalAnimals()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"\nThe total number of animals in the zoo is {_animals.Count}.");
			Console.ResetColor();
		}

		// Display total daily food consumption of all animals
		public void DisplayTotalFoodConsumption()
		{
			var totalFood = _animals.Sum(animal => animal.Food);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"\nThe total daily food consumption of all animals is {totalFood} units.");
			Console.ResetColor();
		}

		// Try to add a new animal to the zoo
		public bool TryAddAnimal(Animal animal)
		{
			animal.Number = _numberGenerator.NewNumber();

			if (Clinic.VerifyHealthStatus(animal))
			{
				_animals.Add(animal);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"{animal.Name} has been successfully added to the zoo.");
				Console.ResetColor();
				return true;
			}

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Unable to add {animal.Name} to the zoo due to health issues.");
			Console.ResetColor();
			return false;
		}

		// Try to add a new item to the inventory
		public bool TryAddThing(Thing thing)
		{
			thing.Number = _numberGenerator.NewNumber();

			_things.Add(thing);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"{thing.Name} has been successfully added to the inventory.");
			Console.ResetColor();
			return true;
		}

		// Show contact zoo animals (those suitable for petting)
		public void ShowContactZooAnimals()
		{
			_contactAnimals.Clear();

			foreach (var animal in _animals)
			{
				if (animal is Herbo herbivore && herbivore.Kindness > 5)
				{
					_contactAnimals.Add(herbivore);
				}
			}

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\nAnimals suitable for the petting zoo:");
			Console.ResetColor();

			int columnWidth = 25;
			Console.WriteLine($"{"Name".PadRight(columnWidth)}{"Kindness Level".PadRight(columnWidth)}");
			Console.WriteLine(new string('-', columnWidth * 2));

			foreach (var animal in _contactAnimals)
			{
				Console.WriteLine($"{animal.Name.PadRight(columnWidth)}{animal.Kindness.ToString().PadRight(columnWidth)}");
			}
		}

		// Perform an inventory check and display the zoo inventory
		public void PerformInventoryCheck()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n┌──────────────────────────────────────┐");
			Console.WriteLine("│             INVENTORY CHECK          │");
			Console.WriteLine("└──────────────────────────────────────┘");
			Console.ResetColor();

			DisplayInventory("ANIMALS", _animals);
			DisplayInventory("THINGS", _things);
		}

		// Display inventory of animals or items
		private void DisplayInventory<T>(string categoryName, List<T> items)
		{
			int totalWidth = 40;
			int categoryWidth = categoryName.Length;
			int padding = (totalWidth - categoryWidth) / 2;

			Console.WriteLine(new string('=', totalWidth));
			Console.WriteLine($"{new string(' ', padding)}{categoryName}{new string(' ', padding)}");
			Console.WriteLine(new string('=', totalWidth));

			int columnWidth = 20;
			Console.WriteLine($"{"Name".PadRight(columnWidth)}{"Number".PadLeft(columnWidth)}");
			Console.WriteLine(new string('-', columnWidth * 2));

			foreach (var item in items)
			{
				string name = item is Animal animal ? animal.Name : item is Thing thing ? thing.Name : "";
				string number = item is Animal animalItem ? animalItem.Number.ToString() : item is Thing thingItem ? thingItem.Number.ToString() : "";
				Console.WriteLine($"{name.PadRight(columnWidth)}{number.PadLeft(columnWidth - 2)}");
			}
		}
	}
}
