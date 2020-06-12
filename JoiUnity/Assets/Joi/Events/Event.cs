using System;
using UnityEngine;

namespace Joi.Events
{
	[CreateAssetMenu(menuName = "Joi/Events/Empty")]
	public class Event : ScriptableObject
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		public Action OnTrigger;

		public void Trigger()
		{
			OnTrigger?.Invoke();
		}
	}

	public abstract class Event<TValue> : ScriptableObject
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		public Action<TValue> OnTrigger;

		public void Trigger(TValue value)
		{
			OnTrigger?.Invoke(value);
		}
	}
}