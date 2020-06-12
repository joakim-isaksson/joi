using UnityEngine;

namespace Joi.Events
{
	public class OnTriggerVector3 : OnTrigger<UnityEventVector3, Vector3>
	{
		public void TriggerNormalized(Vector3 value)
		{
			Trigger(value.normalized);
		}

		public void TriggerMagnitude(Vector3 value)
		{
			Trigger(value.magnitude);
		}

		public void Trigger(int value)
		{
			Trigger(new Vector3(value, value, value));
		}

		public void Trigger(float value)
		{
			Trigger(new Vector3(value, value, value));
		}

		public void TriggerWorldPos(GameObject value)
		{
			Trigger(value.transform.position);
		}

		public void TriggerLocalPos(GameObject value)
		{
			Trigger(value.transform.localPosition);
		}
	}
}