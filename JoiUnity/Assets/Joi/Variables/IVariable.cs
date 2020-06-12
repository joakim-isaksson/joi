using System;

namespace Joi.Variables
{
	public interface IVariable<TType>
	{
		Action<TType> OnValueChanged { get; set; }
		TType Value { get; set; }
	}
}