using System;
using UnityEngine;

namespace Joi.Hexagon
{
	public struct FractionalHex
	{
		public readonly float A;
		public readonly float B;
		public readonly float C;

		public FractionalHex(float a, float b, float c)
		{
			A = a;
			B = b;
			C = c;
		}

		public Hex Round()
		{
			var a = Mathf.RoundToInt(A);
			var b = Mathf.RoundToInt(B);
			var c = Mathf.RoundToInt(C);

			var aDiff = Math.Abs(a - A);
			var bDiff = Math.Abs(b - B);
			var cDiff = Math.Abs(c - C);

			if (aDiff > bDiff && aDiff > cDiff)
			{
				a = -b - c;
			}
			else if (bDiff > cDiff)
			{
				b = -a - c;
			}
			else
			{
				c = -a - b;
			}

			return new Hex(a, b, c);
		}
	}
}