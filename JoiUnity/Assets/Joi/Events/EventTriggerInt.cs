using UnityEngine;

namespace Joi.Events
{
	public class EventTriggerInt : EventTrigger<EventInt, int>
	{
		public void TriggerNegate(int value)
		{
			Trigger(-value);
		}

		public void Trigger(bool value)
		{
			Trigger(value ? 1 : 0);
		}

		public void Trigger(string value)
		{
			Trigger(int.Parse(value));
		}

		public void TriggerRound(float value)
		{
			Trigger(Mathf.RoundToInt(value));
		}

		public void TriggerFloor(float value)
		{
			Trigger(Mathf.FloorToInt(value));
		}

		public void TriggerCeil(float value)
		{
			Trigger(Mathf.CeilToInt(value));
		}

		public void Trigger(GameObject value)
		{
			Trigger(value.GetInstanceID());
		}
	}
}