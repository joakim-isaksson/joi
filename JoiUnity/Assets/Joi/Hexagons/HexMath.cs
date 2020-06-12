using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Joi.Hexagon
{
	public static class HexMath
	{
		public static int Distance(Hex a, Hex b)
		{
			return (a - b).Magnitude;
		}

		public static FractionalHex Lerp(Hex from, Hex to, float t)
		{
			return new FractionalHex(
				from.A + (to.A - from.A) * t,
				from.B + (to.B - from.B) * t,
				from.C + (to.C - from.C) * t
			);
		}

		public static Hex Rotate(Hex hex, int degrees)
		{
			if (degrees > 0)
			{
				for (var i = 0; i < degrees / 60; ++i)
				{
					hex = new Hex(-hex.C, -hex.A, -hex.B);
				}
			}
			else
			{
				for (var i = 0; i < Mathf.Abs(degrees / 60); ++i)
				{
					hex = new Hex(-hex.B, -hex.C, -hex.A);
				}
			}

			return hex;
		}

		// TODO: zero allocation version
		public static IList<Hex> Line(Hex from, Hex to)
		{
			var distance = (from - to).Magnitude;
			var line = new Hex[distance];

			var step = 1.0f / Mathf.Max(distance, 1);
			for (var i = 0; i <= distance; ++i)
			{
				line[i] = Lerp(@from, to, step * i).Round();
			}

			return line;
		}

		// TODO: zero allocation version
		public static IList<Hex> Path(Hex from, Hex to, ISet<Hex> blocked)
		{
			var visited = new HashSet<Hex> {from};

			var nodes = new List<HexNode> {new HexNode(from, null)};

			while (nodes.Count > 0)
			{
				var newNodes = new List<HexNode>();
				foreach (var node in nodes)
				foreach (var unit in Hex.Directions)
				{
					var candidate = node.Hex + unit;
					if (visited.Contains(candidate) || blocked.Contains(candidate))
					{
						continue;
					}

					visited.Add(candidate);
					newNodes.Add(new HexNode(candidate, node));

					if (candidate.Equals(to))
					{
						return newNodes[newNodes.Count - 1].ToList();
					}
				}

				nodes = newNodes;
			}

			return null;
		}

		// TODO: zero allocation version
		public static HashSet<Hex> Polygon(List<Hex> corners)
		{
			var polygon = new HashSet<Hex>();
			for (var from = 0; from < corners.Count; ++from)
			{
				var to = from == corners.Count - 1 ? 0 : from + 1;
				foreach (var h in Line(corners[from], corners[to]))
				{
					polygon.Add(h);
				}
			}

			return polygon;
		}

		// TODO: zero allocation version
		public static bool LineOfSight(Hex from, Hex to, ISet<Hex> blocked)
		{
			var line = Line(from, to);
			foreach (var t in line)
			{
				if (blocked.Contains(t))
				{
					return false;
				}
			}

			return true;
		}

		// TODO: zero allocation version
		public static IList<Hex> Circle(Hex origin, int radius)
		{
			var hexes = new List<Hex>();
			for (var a = -radius; a <= radius; ++a)
			{
				var bMin = Mathf.Max(-radius, -a - radius);
				var bMax = Mathf.Min(radius, -a + radius);
				for (var b = bMin; b <= bMax; ++b)
				{
					var c = -a - b;
					hexes.Add(origin + new Hex(a, b, c));
				}
			}

			return hexes;
		}

		// TODO: zero allocation version
		public static IList<Hex> Reachable(Hex origin, int steps, ISet<Hex> blocked)
		{
			var visited = new HashSet<Hex> {origin};

			var fringes = new List<List<Hex>> {new List<Hex>()};
			fringes[0].Add(origin);

			for (var step = 1; step <= steps; ++step)
			{
				fringes.Add(new List<Hex>());
				foreach (var hex in fringes[step - 1])
				{
					foreach (var unit in Hex.Directions)
					{
						var candidate = hex + unit;
						if (!blocked.Contains(candidate) && !visited.Contains(candidate))
						{
							visited.Add(candidate);
							fringes[step].Add(candidate);
						}
					}
				}
			}

			return visited.ToList();
		}

		// TODO: zero allocation version
		public static IList<Hex> Ring(Hex origin, int radius)
		{
			var hexes = new List<Hex>();
			var hex = origin + Hex.N * radius;
			foreach (var unit in Hex.Directions)
			{
				for (var i = 0; i < radius; ++i)
				{
					hexes.Add(hex);
					hex += unit;
				}
			}

			return hexes;
		}

		// TODO: zero allocation version
		public static List<Hex> Spiral(Hex origin, int radius)
		{
			var hexes = new List<Hex> {origin};
			for (var r = 1; r <= radius; ++r)
			{
				hexes.AddRange(Ring(origin, r));
			}

			return hexes;
		}
	}
}