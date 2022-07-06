using System;
using System.Collections.Generic;
using System.Text;

namespace DAG
{
	public class Program
	{
		static void Main(string[] args)
		{
			TransformNode a = new TransformNode("a");
			TransformNode b = new TransformNode("b");
			TransformNode c = new TransformNode("c");
			TransformNode d = new TransformNode("d");
			TransformNode e = new TransformNode("e");
			TransformNode f = new TransformNode("f");
			TransformNode g = new TransformNode("g");
			TransformNode h = new TransformNode("h");

			b.SetParent(a);
			c.SetParent(b);
			e.SetParent(d);
			f.SetParent(d);
			g.SetParent(d);
			h.SetParent(f);
			
			

			CommandManager.ProcessCommand("ls");

			while (!CommandManager.Done)
			{
				Console.Write(":");

				CommandManager.ProcessCommand(Console.ReadLine());
			}

		}
	}
}
	
 