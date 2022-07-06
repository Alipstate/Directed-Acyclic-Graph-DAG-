using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class CommandExit : Command

	{
		public CommandExit(string commandName) : base(commandName) { }

		public override string Process(string[] arguments)
		{
			string output = "Exiting Now";

			CommandManager.Done = true;

			return output;
		}
	}
}