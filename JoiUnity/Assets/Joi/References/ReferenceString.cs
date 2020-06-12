using System;
using Joi.Variables;

namespace Joi.References
{
	[Serializable]
	public class ReferenceString
	{
		public string Constant;
		public bool UseVariable;
		public VariableString Variable;

		public ReferenceString()
		{
		}

		public ReferenceString(string value)
		{
			Constant = value;
		}

		public string Value
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
			return Value;
		}

		public static implicit operator string(ReferenceString reference)
		{
			return reference.Value;
		}
	}
}