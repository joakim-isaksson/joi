using UnityEngine;

namespace Joi.Events
{
	public class EventTriggerBool : EventTrigger<EventBool, bool>
	{
		public void TriggerInverted(bool value)
		{
			Trigger(!value);
		}

		public void Trigger(string value)
		{
			Trigger(bool.Parse(value));
		}

		public void Trigger(int value)
		{
			Trigger(value != 0);
		}

		public void Trigger(float value)
		{
			Trigger(!Mathf.Approximately(0f, value));
		}

		public void Trigger(GameObject value)
		{
			Trigger(value != null);
		}
	}
}