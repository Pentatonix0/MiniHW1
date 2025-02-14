using System;


namespace ConsoleApp.Services
{
	public class NumberGenerator
	{
		int last_number = 1;
		public int NewNumber()
		{
			this.last_number += 1;
			return this.last_number;
		}
	}
}