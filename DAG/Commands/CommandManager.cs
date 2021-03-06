using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public static class CommandManager
	{
		public static bool Done = false;
		private static List<Command> commandList = new List<Command>();

		static CommandManager()
		{
			//viewing commands
			commandList.Add(new CommandClear("clear"));
			commandList.Add(new CommandExit("exit"));
			commandList.Add(new CommandLs("ls"));
			
			//creation commands
			commandList.Add(new CommandCreate("sphere"));
			commandList.Add(new CommandCreate("light"));

			//editing commands
			commandList.Add(new CommandDelete("delete"));
			commandList.Add(new CommandParent("parent"));
			commandList.Add(new CommandUnparent("unparent"));
			commandList.Add(new CommandGroup("group"));
			commandList.Add(new CommandRename("rename"));
		}
		public static void ProcessCommand(string line)
		{
			string [] arguments = line.Split(' ');

			if (arguments.Length > 0)
			{
				string output = null;

				int i = 0;
				for (; i < commandList.Count; i++)
				{
					if (commandList[i].ComandName == arguments[0])
					{
						output = commandList[i].Process(arguments);
						break;
					}
				}

				 if (i < commandList.Count)
				{
					if (output.Length > 0)
						Console.WriteLine(output);
					
				}
				else
				{
					Console.WriteLine("Invalid Command");
				}
			}
		}

	}
}
