using System;
using Joi.Variables;

namespace Joi.References
{
	[Serializable]
	public class ReferenceFloat
	{
		public float Constant;
		public bool UseVariable;
		public VariableFloat Variable;

		public ReferenceFloat()
		{
		}

		public ReferenceFloat(float value)
		{
			Constant = value;
		}

		public ReferenceFloat(VariableFloat value)
		{
			Variable = value;
			UseVariable = true;
		}

		public float Value
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

		public static implicit operator float(ReferenceFloat reference)
		{
			return reference.Value;
		}
	}
}