using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class CommandUnparent : Command

	{
		public CommandUnparent(string commandName) : base(commandName) { }

		public override string Process(string[] arguments)
		{
			string output = "";

			if (arguments.Length == 2)
			{
				TransformNode node = TransformNode.Find(arguments[1]) as TransformNode;
				if (node != null)
					node.SetParent(null);
				else
					output = $"Could not find the specified node: {arguments[1]}";
			}
			else
				output = "You must specify a single node";

			return output;
		}
	}
}
