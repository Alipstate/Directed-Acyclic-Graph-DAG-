using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAG
{
	public class TransformNode : Node
	{
		private const int TREE_DRAW_OFFSET = 4;
		private const char CHAR_HLINE = (char)0x2500;
		private const char CHAR_VLINE = (char)0x2502;
		private const char CHAR_TJOINT = (char)0x251C;
		private const char CHAR_ANGLE = (char)0x2514;

		private TransformNode parent;
		private ShapeNode _shape;

		private static List<TransformNode> rootNodes;

		private List<TransformNode> children;

		static TransformNode()
		{
			rootNodes = new List<TransformNode>();
		}

		public TransformNode(string name)
		{
			string validatedName = name;
			int counter = 2;
			while (TransformNode.Find(validatedName) != null)
			{
				validatedName = name + counter.ToString();
				counter++;
			}

			children = new List<TransformNode>();
			Name = validatedName;
			rootNodes.Add(this);
		}   

		public TransformNode() : this("Transform") { }

		public void SetParent(TransformNode parent)
		{
			//remove from old containing list
			if (this.parent == null)
				rootNodes.Remove(this);
			else 
				this.parent.children.Remove(this);

			//Assign new parent 

			this.parent = parent;

			if (parent == null)
				rootNodes.Add(this);
			else
				parent.children.Add(this);
		} 

		public void SetShape(ShapeNode shape)
		{
			_shape = shape;
		}

		public static Node Find(string name)
		{
			foreach(TransformNode node in rootNodes)
			{
				Node result = node.FindNode(name);
				if(result != null)
					return result;
			}
			return null;
		}
		 
		public Node FindNode(string name)
		{
			Node result = null;
			FindNode(name, ref result);
			return result;
		}

		private void FindNode(string name, ref Node result)
		{
			if(this.Name == name)
				result = this;
			else if (this._shape != null && this._shape.Name == name)
					result = this._shape;
			else 
				foreach(TransformNode child in children)  
					child.FindNode(name, ref result);
		}

		public static void ShowAll()
		{
			ShowTree(rootNodes, "");
		}

		public void ShowTree()
		{
			ShowTree(this.children, "");	 
		}

		private static void ShowTree(List<TransformNode> nodeList, string padding)
		{
			for(int i = 0; i < nodeList.Count; i++)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(padding);

				StringBuilder padBuilder = new StringBuilder();
				padBuilder.Append(padding);


				if (i < nodeList.Count - 1)
				{
					sb.Append(CHAR_TJOINT);

					padBuilder.Append(CHAR_VLINE);
					padBuilder.Append(' ', TREE_DRAW_OFFSET - 1);
				}
				else
				{
					sb.Append(CHAR_ANGLE);

					padBuilder.Append(' ', TREE_DRAW_OFFSET);
				}
					

				sb.Append(CHAR_HLINE, TREE_DRAW_OFFSET - 1);
				sb.AppendFormat($"{nodeList[i]} [{nodeList[i]._shape}]");

				Console.WriteLine(sb.ToString());
				ShowTree(nodeList[i].children, padBuilder.ToString());
			}

			
		}
		//private void ShowTree(int depth)
		//{
		//	string padding = "";
		//	padding = padding.PadLeft(depth * 2, '-');
		//	Console.WriteLine(padding + this + " [" + _shape + "]" );

		//	foreach (TransformNode child in children)
		//		child.ShowTree(depth + 1);
		

		public void RemoveNode()
		{
			RemoveShape();
			if (parent != null)
				parent.children.Remove(this);
			else
				rootNodes.Remove(this);    
		}

		private void RemoveShape()
		{
			ShapeNode.RemoveNode(this._shape);
			foreach (TransformNode child in children)
				child.RemoveShape();
		}

		public static void Group(TransformNode node1, TransformNode node2)
		{
			TransformNode groupNode = new TransformNode("Group");
			node1.SetParent(groupNode);
			node2.SetParent(groupNode);
		}

		public static void Group(TransformNode node1)
		{ 
			TransformNode groupNode = new TransformNode("Group");
			node1.SetParent(groupNode);
		}

	}
}
