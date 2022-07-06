using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public abstract class Command
	{
		private string _commandName;

		public string ComandName { get { return _commandName; } }

		public Command(string ComandName)
		{
			_commandName = ComandName;
		}

		public abstract string Process(string[] arguments);
		

	}
}
