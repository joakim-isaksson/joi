using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	public class OnJoiEvent : MonoBehaviour
	{
		[SerializeField] private JoiEvent _event;

		[SerializeField] private Filter _filter;
		[SerializeField] private Converter _converter;

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
			_event = null;

			_filter = null;
			_converter = null;

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

		private void OnEnable()
		{
			if (_event == null)
			{
				Debug.LogAssertion("Missing event reference", this);
				return;
			}

			switch (_event.Parameter)
			{
				case JoiEvent.ParameterType.None:
					_event.OnTrigger += Filter;
					break;
				case JoiEvent.ParameterType.Boolean:
					_event.OnTriggerBoolean += Filter;
					break;
				case JoiEvent.ParameterType.Color:
					_event.OnTriggerColor += Filter;
					break;
				case JoiEvent.ParameterType.Float:
					_event.OnTriggerFloat += Filter;
					break;
				case JoiEvent.ParameterType.GameObject:
					_event.OnTriggerGameObject += Filter;
					break;
				case JoiEvent.ParameterType.Integer:
					_event.OnTriggerInteger += Filter;
					break;
				case JoiEvent.ParameterType.Material:
					_event.OnTriggerMaterial += Filter;
					break;
				case JoiEvent.ParameterType.Object:
					_event.OnTriggerObject += Filter;
					break;
				case JoiEvent.ParameterType.Sprite:
					_event.OnTriggerSprite += Filter;
					break;
				case JoiEvent.ParameterType.String:
					_event.OnTriggerString += Filter;
					break;
				case JoiEvent.ParameterType.Vector3:
					_event.OnTriggerVector3 += Filter;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_converter.OnResultBoolean += Trigger;
			_converter.OnResultFloat += Trigger;
			_converter.OnResultInteger += Trigger;
			_converter.OnResultString += Trigger;
		}

		private void OnDisable()
		{
			if (_event == null)
			{
				Debug.LogAssertion("Missing event reference", this);
				return;
			}

			switch (_event.Parameter)
			{
				case JoiEvent.ParameterType.None:
					_event.OnTrigger -= Filter;
					break;
				case JoiEvent.ParameterType.Boolean:
					_event.OnTriggerBoolean -= Filter;
					break;
				case JoiEvent.ParameterType.Color:
					_event.OnTriggerColor -= Filter;
					break;
				case JoiEvent.ParameterType.Float:
					_event.OnTriggerFloat -= Filter;
					break;
				case JoiEvent.ParameterType.GameObject:
					_event.OnTriggerGameObject -= Filter;
					break;
				case JoiEvent.ParameterType.Integer:
					_event.OnTriggerInteger -= Filter;
					break;
				case JoiEvent.ParameterType.Material:
					_event.OnTriggerMaterial -= Filter;
					break;
				case JoiEvent.ParameterType.Object:
					_event.OnTriggerObject -= Filter;
					break;
				case JoiEvent.ParameterType.Sprite:
					_event.OnTriggerSprite -= Filter;
					break;
				case JoiEvent.ParameterType.String:
					_event.OnTriggerString -= Filter;
					break;
				case JoiEvent.ParameterType.Vector3:
					_event.OnTriggerVector3 -= Filter;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_converter.OnResultBoolean -= Trigger;
			_converter.OnResultFloat -= Trigger;
			_converter.OnResultInteger -= Trigger;
			_converter.OnResultString -= Trigger;
		}

		private void Filter()
		{
			if (_event.Parameter != JoiEvent.ParameterType.None)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger();
		}

		private void Filter(bool value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Boolean)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void Filter(Color value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(float value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Float)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void Filter(GameObject value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(int value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Integer)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void Filter(Material value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(Object value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(Sprite value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(string value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.String)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void Filter(Vector3 value)
		{
			if (_event.Parameter != JoiEvent.ParameterType.Vector3)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Trigger()
		{
			_onEvent?.Invoke();
		}

		private void Trigger(bool value)
		{
			_onEventBoolean?.Invoke(value);
		}

		private void Trigger(float value)
		{
			_onEventFloat?.Invoke(value);
		}

		private void Trigger(int value)
		{
			_onEventInteger?.Invoke(value);
		}

		private void Trigger(string value)
		{
			_onEventString?.Invoke(value);
		}

		private void Trigger(Color value)
		{
			_onEventColor?.Invoke(value);
		}

		private void Trigger(GameObject value)
		{
			_onEventGameObject?.Invoke(value);
		}

		private void Trigger(Material value)
		{
			_onEventMaterial?.Invoke(value);
		}

		private void Trigger(Object value)
		{
			_onEventObject?.Invoke(value);
		}

		private void Trigger(Sprite value)
		{
			_onEventSprite?.Invoke(value);
		}

		private void Trigger(Vector3 value)
		{
			_onEventVector3?.Invoke(value);
		}
	}
}