namespace ConsoleApp.Domain.Animals
{
	public abstract class Animal : IAlive, IInventory
	{
		public required int Food { get; set; }
		public required string Name { get; set; }
		public required bool IsHealthy { get; set; }
		public int Number { get; set; }
	}
}