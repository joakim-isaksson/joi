using System;
using Joi.UIVariables;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceInt
	{
		public int Constant;
		public bool UseVariable;
		public UIVariableInt Variable;

		public UIReferenceInt()
		{
		}

		public UIReferenceInt(int value)
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

		public static implicit operator int(UIReferenceInt uiReference)
		{
			return uiReference.Value;
		}
	}
}