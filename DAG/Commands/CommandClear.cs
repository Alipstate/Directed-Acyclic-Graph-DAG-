using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	class CommandClear : Command
	{
		public CommandClear(string ComandName) : base(ComandName)
		{
		}

		public override string Process(string[] arguments)
		{
			string output = "";

			if (arguments.Length == 1)
				Console.Clear();
			else
				output = "Clear requires no parameters";
				
				return output;

		}
	}
}
