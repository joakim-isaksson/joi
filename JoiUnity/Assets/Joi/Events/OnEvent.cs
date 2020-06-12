using UnityEngine;
using UnityEngine.Events;

namespace Joi.Events
{
	public class OnEvent : MonoBehaviour
	{
		[SerializeField] private Event _event;
		[SerializeField] private UnityEvent _onEvent;

		private void Reset()
		{
			_event = null;
			_onEvent = null;
		}

		private void OnEnable()
		{
			if (_event == null)
			{
				Debug.LogWarning("Missing reference to Event", this);
				return;
			}

			_event.OnTrigger += Trigger;
		}

		private void OnDisable()
		{
			if (_event == null)
			{
				Debug.LogWarning("Missing reference to Event", this);
				return;
			}

			_event.OnTrigger -= Trigger;
		}

		private void Trigger()
		{
			if (_onEvent == null)
			{
				Debug.LogWarning("No actions on event", this);
				return;
			}

			_onEvent.Invoke();
		}
	}

	public abstract class OnEvent<TEvent, TUnityEvent, TValue> : MonoBehaviour
		where TEvent : Event<TValue>
		where TUnityEvent : UnityEvent<TValue>
	{
		[SerializeField] private TEvent _event;
		[SerializeField] private TUnityEvent _onEvent;

		private void Reset()
		{
			_event = null;
			_onEvent = null;
		}

		private void OnEnable()
		{
			if (_event == null)
			{
				Debug.LogWarning("Missing reference to Event", this);
				return;
			}

			_event.OnTrigger += Trigger;
		}

		private void OnDisable()
		{
			if (_event == null)
			{
				Debug.LogWarning("Missing reference to Event", this);
				return;
			}

			_event.OnTrigger -= Trigger;
		}

		private void Trigger(TValue value)
		{
			if (_onEvent == null)
			{
				Debug.LogWarning("No actions on event", this);
				return;
			}

			_onEvent.Invoke(value);
		}
	}
}