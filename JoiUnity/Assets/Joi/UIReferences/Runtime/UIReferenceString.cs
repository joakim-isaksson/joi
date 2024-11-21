using System;
using Joi.UIVariables;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceString
	{
		public string Constant;
		public bool UseVariable;
		public UIVariableString Variable;

		public UIReferenceString()
		{
		}

		public UIReferenceString(string value)
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

		public static implicit operator string(UIReferenceString uiReference)
		{
			return uiReference.Value;
		}
	}
}