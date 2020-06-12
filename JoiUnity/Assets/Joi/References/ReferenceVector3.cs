using System;
using Joi.Variables;
using UnityEngine;

namespace Joi.References
{
	[Serializable]
	public class ReferenceVector3
	{
		public Vector3 Constant;
		public bool UseVariable;
		public VariableVector3 Variable;

		public ReferenceVector3()
		{
		}

		public ReferenceVector3(Vector3 value)
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

		public static implicit operator Vector3(ReferenceVector3 reference)
		{
			return reference.Value;
		}
	}
}