using UnityEngine;

namespace Joi.Events
{
	public class OnTriggerString : OnTrigger<UnityEventString, string>
	{
		public void Trigger(bool value)
		{
			Trigger(value.ToString());
		}

		public void Trigger(int value)
		{
			Trigger(value.ToString());
		}

		public void Trigger(GameObject value)
		{
			Trigger(value.name);
		}

		public void TriggerToUpperCase(string value)
		{
			Trigger(value.ToUpper());
		}

		public void TriggerToLowerCase(string value)
		{
			Trigger(value.ToLower());
		}

		public void Trigger(float value)
		{
			Trigger(value.ToString("F"));
		}

		public void TriggerF0(float value)
		{
			Trigger(value.ToString("F0"));
		}

		public void TriggerF1(float value)
		{
			Trigger(value.ToString("F1"));
		}

		public void TriggerF2(float value)
		{
			Trigger(value.ToString("F2"));
		}

		public void TriggerP0(float value)
		{
			Trigger(value.ToString("P0"));
		}

		public void TriggerP1(float value)
		{
			Trigger(value.ToString("P1"));
		}

		public void TriggerP2(float value)
		{
			Trigger(value.ToString("P2"));
		}
	}
}