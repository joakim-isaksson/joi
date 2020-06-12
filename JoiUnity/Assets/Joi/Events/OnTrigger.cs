using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Joi.Events
{
	public class OnTrigger : MonoBehaviour
	{
		[SerializeField] private TriggerType _trigger;
		[SerializeField] private float _triggerDelay;
		[SerializeField] private UnityEvent _onTrigger;

		private void Reset()
		{
			_trigger = TriggerType.Manual;
			_triggerDelay = 0f;
			_onTrigger = null;
		}

		private void Awake()
		{
			if (_trigger == TriggerType.OnAwake)
			{
				Trigger();
			}
		}

		private void Start()
		{
			if (_trigger == TriggerType.OnStart)
			{
				Trigger();
			}
		}

		private void OnEnable()
		{
			if (_trigger == TriggerType.OnEnable)
			{
				Trigger();
			}
		}

		private void OnDisable()
		{
			if (_trigger == TriggerType.OnDisable)
			{
				Trigger();
			}
		}

		private void OnDestroy()
		{
			if (_trigger == TriggerType.OnDestroy)
			{
				Trigger();
			}
		}

		public void Trigger()
		{
			if (_triggerDelay > 0f)
			{
				StartCoroutine(InvokeAfterDelay(_triggerDelay));
			}
			else
			{
				_onTrigger?.Invoke();
			}
		}

		public void TriggerWithDelay(float delay)
		{
			StartCoroutine(InvokeAfterDelay(delay));
		}

		private IEnumerator InvokeAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			_onTrigger?.Invoke();
		}
	}

	public abstract class OnTrigger<TUnityEvent, TValue> : MonoBehaviour where TUnityEvent : UnityEvent<TValue>
	{
		[SerializeField] private TriggerType _trigger;
		[SerializeField] private TValue _triggerValue;
		[SerializeField] private float _triggerDelay;
		[SerializeField] private TUnityEvent _onTrigger;

		private void Reset()
		{
			_trigger = TriggerType.Manual;
			_triggerValue = default;
			_triggerDelay = 0f;
			_onTrigger = null;
		}

		private void Awake()
		{
			if (_trigger == TriggerType.OnAwake)
			{
				Trigger();
			}
		}

		private void Start()
		{
			if (_trigger == TriggerType.OnStart)
			{
				Trigger();
			}
		}

		private void OnEnable()
		{
			if (_trigger == TriggerType.OnEnable)
			{
				Trigger();
			}
		}

		private void OnDisable()
		{
			if (_trigger == TriggerType.OnDisable)
			{
				Trigger();
			}
		}

		private void OnDestroy()
		{
			if (_trigger == TriggerType.OnDestroy)
			{
				Trigger();
			}
		}

		public void Trigger()
		{
			Trigger(_triggerValue);
		}

		public void Trigger(TValue value)
		{
			if (_triggerDelay > 0f)
			{
				StartCoroutine(InvokeAfterDelay(value));
			}
			else
			{
				_onTrigger?.Invoke(value);
			}
		}

		private IEnumerator InvokeAfterDelay(TValue value)
		{
			yield return new WaitForSeconds(_triggerDelay);
			_onTrigger?.Invoke(value);
		}
	}
}