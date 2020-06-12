using System;
using Joi.Variables;

namespace Joi.References
{
	[Serializable]
	public class ReferenceBool
	{
		public bool Constant;
		public bool UseVariable;
		public VariableBool Variable;

		public ReferenceBool()
		{
		}

		public ReferenceBool(bool value)
		{
			Constant = value;
		}

		public bool Value
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

		public static implicit operator bool(ReferenceBool reference)
		{
			return reference.Value;
		}
	}
}