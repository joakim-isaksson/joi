using UnityEngine;

namespace Joi.Events
{
	public class OnTriggerFloat : OnTrigger<UnityEventFloat, float>
	{
		public void TriggerNegate(float value)
		{
			Trigger(-value);
		}

		public void Trigger(bool value)
		{
			Trigger(value ? 1f : 0f);
		}

		public void Trigger(string value)
		{
			Trigger(float.Parse(value));
		}

		public void Trigger(int value)
		{
			Trigger((float) value);
		}

		public void Trigger(GameObject value)
		{
			Trigger(value.GetInstanceID());
		}
	}
}