using System;


namespace ConsoleApp.Domain.Animals
{
	public abstract class Animal : IAlive, IInventory
	{
		public int Food { get; set; }
		public required string Name { get; set; }
		public bool IsHealthy { get; set; }
		public int Number { get; set; }
	}
}