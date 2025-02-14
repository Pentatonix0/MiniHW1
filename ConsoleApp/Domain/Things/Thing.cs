using ConsoleApp.Domain.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domain.Things
{
	public abstract class Thing : IInventory
	{
		public int Number { get; set; }
		public required string Name { get; set; }
	}
}