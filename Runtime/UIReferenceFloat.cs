using System;
using Joi.UIVariables;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceFloat
	{
		public float Constant;
		public bool UseVariable;
		public UIVariableFloat Variable;

		public UIReferenceFloat()
		{
		}

		public UIReferenceFloat(float value)
		{
			Constant = value;
		}

		public UIReferenceFloat(UIVariableFloat value)
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

		public static implicit operator float(UIReferenceFloat uiReference)
		{
			return uiReference.Value;
		}
	}
}