using ConsoleApp.Domain.Animals;
namespace ConsoleApp.Domain.Zoo
{

	public class VeterinaryClinic : IVeterinaryClinic
	{
		public bool CheckHealth(Animal animal)
		{
			return animal.IsHealthy;
		}
	}
}