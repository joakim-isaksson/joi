using System;

namespace Joi.UIVariables
{
	public interface UIVariable<TType>
	{
		Action<TType> OnValueChanged { get; set; }
		TType Value { get; set; }
	}
}