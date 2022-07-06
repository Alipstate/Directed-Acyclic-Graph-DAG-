using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class CommandTemplate : Command

	{
		public CommandTemplate(string commandName) : base(commandName) { }

			public override string Process (string[] arguments)
		{
			string output = "";
			
			//processing code here

			return output;
		}
	}
}
