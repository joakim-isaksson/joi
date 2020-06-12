using System;
using Joi.Variables;

namespace Joi.References
{
	[Serializable]
	public class ReferenceInt
	{
		public int Constant;
		public bool UseVariable;
		public VariableInt Variable;

		public ReferenceInt()
		{
		}

		public ReferenceInt(int value)
		{
			Constant = value;
		}

		public int Value
		{
			get => UseVariable ? Variable.Value : Constant;
			set
			{
				if (UseVariable)
				{
					Variable.Value = value;
				}
				else
				{
					Constant = value;
				}
			}
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public static implicit operator int(ReferenceInt reference)
		{
			return reference.Value;
		}
	}
}