using ConsoleApp.Domain.Animals;
using ConsoleApp.Domain.Things;

namespace ConsoleApp.Domain.Zoo
{

	public class Zoo
	{
		public List<Animal> Animals { get; private set; } = new List<Animal>();
		public List<Herbo> ContactAnimals { get; private set; }
		public List<Thing> Things { get; private set; } = new List<Thing>();

		private readonly IVeterinaryClinic Clinic;


		public Zoo(IVeterinaryClinic clinic)
		{
			this.Clinic = clinic;
		}
	}
}