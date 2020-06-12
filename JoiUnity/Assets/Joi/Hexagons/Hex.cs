using System;
using UnityEngine;

namespace Joi.Hexagon
{
	public struct Hex : IEquatable<Hex>
	{
		public static readonly Hex Zero = new Hex(0, 0, 0);

		public static readonly Hex NE = new Hex(1, 0, -1);
		public static readonly Hex N = new Hex(1, -1, 0);
		public static readonly Hex NW = new Hex(0, -1, 1);
		public static readonly Hex SW = new Hex(-1, 0, 1);
		public static readonly Hex S = new Hex(-1, 1, 0);
		public static readonly Hex SE = new Hex(0, 1, -1);

		public static readonly Hex[] Directions = {NE, N, NW, SW, S, SE};

		public readonly int A;
		public readonly int B;
		public readonly int C;

		public int Magnitude => (Mathf.Abs(A) + Mathf.Abs(B) + Mathf.Abs(C)) / 2;

		public Hex(int a, int b, int c)
		{
			Debug.Assert(a + b + c == 0, "Sum of Hex coordinates must be zero");

			A = a;
			B = b;
			C = c;
		}

		public static Hex FromEven(int x, int y)
		{
			var a = x - (y + y % 2) / 2;
			return new Hex(a, -a - y, y);
		}

		public Vector2Int ToEven()
		{
			return new Vector2Int(A + (C + C % 2) / 2, C);
		}

		public static Hex FromOdd(int x, int y)
		{
			var a = x - (y - y % 2) / 2;
			return new Hex(a, -a - y, y);
		}

		public Vector2Int ToOdd()
		{
			return new Vector2Int(A + (C - C % 2) / 2, C);
		}

		public static Hex operator +(Hex lhs, Hex rhs)
		{
			return new Hex(lhs.A + rhs.A, lhs.B + rhs.B, lhs.C + rhs.C);
		}

		public static Hex operator -(Hex lhs, Hex rhs)
		{
			return new Hex(lhs.A - rhs.A, lhs.B - rhs.B, lhs.C - rhs.C);
		}

		public static Hex operator *(Hex hex, int multiplier)
		{
			return new Hex(hex.A * multiplier, hex.B * multiplier, hex.C * multiplier);
		}

		public static Hex operator *(int multiplier, Hex hex)
		{
			return new Hex(hex.A * multiplier, hex.B * multiplier, hex.C * multiplier);
		}

		public override bool Equals(object other)
		{
			return other is Hex hex && Equals(hex);
		}

		public bool Equals(Hex other)
		{
			return A == other.A && B == other.B && C == other.C;
		}

		public override int GetHashCode()
		{
			return A ^ (B << 4) ^ (B >> 28) ^ (C >> 4) ^ (C << 28);
		}

		public override string ToString()
		{
			return $"({A}, {B}, {C})";
		}
	}
}