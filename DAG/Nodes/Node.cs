using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class Node
	{
		private string _name;
		public string Name { get { return _name; } set { _name = value; } }

		public override string ToString()
		{
			return _name;
		}

	}
}
