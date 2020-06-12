using System;

namespace Joi.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ScriptOrderAttribute : Attribute
	{
		public readonly int Order;

		public ScriptOrderAttribute(int order)
		{
			Order = order;
		}
	}
}