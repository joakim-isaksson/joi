using System.Collections.Generic;

namespace Joi.Hexagon
{
	public class HexNode
	{
		public readonly Hex Hex;
		public readonly HexNode Parent;

		public HexNode(Hex hex, HexNode parent)
		{
			Hex = hex;
			Parent = parent;
		}

		public List<Hex> ToList()
		{
			var list = new List<Hex>();
			AddTo(list);
			return list;
		}

		private void AddTo(IList<Hex> list)
		{
			Parent?.AddTo(list);
			list.Add(Hex);
		}
	}
}