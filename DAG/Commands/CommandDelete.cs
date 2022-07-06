using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class CommandDelete : Command

	{
		public CommandDelete(string commandName) : base(commandName) { }

		public override string Process(string[] arguments)
		{
			string output = "";

			if (arguments.Length == 2)
			{
				TransformNode node = TransformNode.Find(arguments[1]) as TransformNode;
				if (node != null)
					node.RemoveNode();
				else
					output = $"Node not found {arguments[1]}";
			}
			else
				output = "You must enter the name of a sinlge node to remove";

			return output;
		}
	}
}
