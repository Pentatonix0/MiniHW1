using ConsoleApp.Domain.Animals;



namespace ConsoleApp.Domain.Zoo
{
	public interface IVeterinaryClinic
	{
		bool VerifyHealthStatus(Animal animal);
	}
}