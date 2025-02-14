using ConsoleApp.Domain.Animals;
namespace ConsoleApp.Domain.Zoo
{

	public class VeterinaryClinic : IVeterinaryClinic
	{
		public bool VerifyHealthStatus(Animal animal)
		{
			return animal.IsHealthy;
		}
	}
}