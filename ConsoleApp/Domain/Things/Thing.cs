using ConsoleApp.Domain.Animals;

namespace ConsoleApp.Domain.Things
{
	public abstract class Thing : IInventory
	{
		public int Number { get; set; }
		public required string Name { get; set; }
	}
}