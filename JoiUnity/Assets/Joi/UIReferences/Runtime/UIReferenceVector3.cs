using System;
using Joi.UIVariables;
using UnityEngine;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceVector3
	{
		public Vector3 Constant;
		public bool UseVariable;
		public UIVariableVector3 Variable;

		public UIReferenceVector3()
		{
		}

		public UIReferenceVector3(Vector3 value)
		{
			Constant = value;
		}

		public Vector3 Value
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

		public static implicit operator Vector3(UIReferenceVector3 uiReference)
		{
			return uiReference.Value;
		}
	}
}