using ConsoleApp.Domain.Animals;
using System;

namespace ConsoleApp.Domain.Zoo
{
	public interface IVeterinaryClinic
	{
		bool CheckHealth(Animal animal);
	}
}