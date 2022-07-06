using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class CommandRename : Command

	{
		public CommandRename(string commandName) : base(commandName) { }

		public override string Process(string[] arguments)
		{
			string output = "";

			if (arguments.Length == 3)
			{
				Node node = TransformNode.Find(arguments[1]);
				if (node != null)
				{
					if (TransformNode.Find(arguments[2]) == null)
						node.Name = arguments[2];
					else
						output = "The target name already exists";
				}
				else
					output = $"Could not find specified node: {arguments[1]}";
			}
			else output = "You must specify the old name and the new name";

			return output;
		}
	}
}
 