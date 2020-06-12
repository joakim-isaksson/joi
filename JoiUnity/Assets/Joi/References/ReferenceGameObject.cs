using System;
using Joi.Variables;
using UnityEngine;

namespace Joi.References
{
	[Serializable]
	public class ReferenceGameObject
	{
		public GameObject Constant;
		public bool UseVariable;
		public VariableGameObject Variable;

		public ReferenceGameObject()
		{
		}

		public ReferenceGameObject(GameObject value)
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

		public static implicit operator GameObject(ReferenceGameObject reference)
		{
			return reference.Value;
		}
	}
}