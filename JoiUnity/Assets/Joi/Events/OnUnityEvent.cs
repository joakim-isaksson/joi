using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	// TODO
	public class OnUnityEvent : MonoBehaviour
	{
		[SerializeField] private TriggerType _trigger;
		[SerializeField] private ParameterType _parameterType;

		[SerializeField] private UnityEvent _onEvent;
		[SerializeField] private UnityEventBoolean _onEventBoolean;
		[SerializeField] private UnityEventColor _onEventColor;
		[SerializeField] private UnityEventFloat _onEventFloat;
		[SerializeField] private UnityEventGameObject _onEventGameObject;
		[SerializeField] private UnityEventInteger _onEventInteger;
		[SerializeField] private UnityEventMaterial _onEventMaterial;
		[SerializeField] private UnityEventObject _onEventObject;
		[SerializeField] private UnityEventSprite _onEventSprite;
		[SerializeField] private UnityEventString _onEventString;
		[SerializeField] private UnityEventVector3 _onEventVector3;

		private void Reset()
		{
			_onEvent = null;
			_onEventBoolean = null;
			_onEventColor = null;
			_onEventFloat = null;
			_onEventGameObject = null;
			_onEventInteger = null;
			_onEventMaterial = null;
			_onEventObject = null;
			_onEventSprite = null;
			_onEventString = null;
			_onEventVector3 = null;
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
			if (_parameterType != ParameterType.None)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEvent?.Invoke();
		}

		public void Trigger(bool value)
		{
			if (_parameterType != ParameterType.Boolean)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventBoolean?.Invoke(value);
		}

		public void Trigger(float value)
		{
			if (_parameterType != ParameterType.Float)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventFloat?.Invoke(value);
		}

		public void Trigger(int value)
		{
			if (_parameterType != ParameterType.Integer)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventInteger?.Invoke(value);
		}

		public void Trigger(string value)
		{
			if (_parameterType != ParameterType.String)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventString?.Invoke(value);
		}

		public void Trigger(Color value)
		{
			if (_parameterType != ParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventColor?.Invoke(value);
		}

		public void Trigger(GameObject value)
		{
			if (_parameterType != ParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventGameObject?.Invoke(value);
		}

		public void Trigger(Material value)
		{
			if (_parameterType != ParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventMaterial?.Invoke(value);
		}

		public void Trigger(Object value)
		{
			if (_parameterType != ParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventObject?.Invoke(value);
		}

		public void Trigger(Sprite value)
		{
			if (_parameterType != ParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventSprite?.Invoke(value);
		}

		public void Trigger(Vector3 value)
		{
			if (_parameterType != ParameterType.Vector3)
			{
				Debug.LogAssertion("Trigger type do not match parameter type", this);
				return;
			}

			_onEventVector3?.Invoke(value);
		}
	}
}