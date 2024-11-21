using System;
using Joi.UIVariables;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceBool
	{
		public bool Constant;
		public bool UseVariable;
		public UIVariableBool Variable;

		public UIReferenceBool()
		{
		}

		public UIReferenceBool(bool value)
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

		public static implicit operator bool(UIReferenceBool uiReference)
		{
			return uiReference.Value;
		}
	}
}