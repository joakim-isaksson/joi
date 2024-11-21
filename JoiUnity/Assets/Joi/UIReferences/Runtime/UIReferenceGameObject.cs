using System;
using Joi.UIVariables;
using UnityEngine;

namespace Joi.UIReferences
{
	[Serializable]
	public class UIReferenceGameObject
	{
		public GameObject Constant;
		public bool UseVariable;
		public UIVariableGameObject Variable;

		public UIReferenceGameObject()
		{
		}

		public UIReferenceGameObject(GameObject value)
		{
			Constant = value;
		}

		public GameObject Value
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

		public static implicit operator GameObject(UIReferenceGameObject uiReference)
		{
			return uiReference.Value;
		}
	}
}