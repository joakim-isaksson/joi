using System;
using Joi.UnityEvents;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.UIEvents
{
	public class OnUIEvent : MonoBehaviour
	{
		[SerializeField] private UIEvent _event;

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

			switch (_event.Type)
			{
				case ParameterType.None:
					_event.OnTrigger += Filter;
					break;
				case ParameterType.Boolean:
					_event.OnTriggerBoolean += Filter;
					break;
				case ParameterType.Color:
					_event.OnTriggerColor += Filter;
					break;
				case ParameterType.Float:
					_event.OnTriggerFloat += Filter;
					break;
				case ParameterType.GameObject:
					_event.OnTriggerGameObject += Filter;
					break;
				case ParameterType.Integer:
					_event.OnTriggerInteger += Filter;
					break;
				case ParameterType.Material:
					_event.OnTriggerMaterial += Filter;
					break;
				case ParameterType.Object:
					_event.OnTriggerObject += Filter;
					break;
				case ParameterType.Sprite:
					_event.OnTriggerSprite += Filter;
					break;
				case ParameterType.String:
					_event.OnTriggerString += Filter;
					break;
				case ParameterType.Vector3:
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

			switch (_event.Type)
			{
				case ParameterType.None:
					_event.OnTrigger -= Filter;
					break;
				case ParameterType.Boolean:
					_event.OnTriggerBoolean -= Filter;
					break;
				case ParameterType.Color:
					_event.OnTriggerColor -= Filter;
					break;
				case ParameterType.Float:
					_event.OnTriggerFloat -= Filter;
					break;
				case ParameterType.GameObject:
					_event.OnTriggerGameObject -= Filter;
					break;
				case ParameterType.Integer:
					_event.OnTriggerInteger -= Filter;
					break;
				case ParameterType.Material:
					_event.OnTriggerMaterial -= Filter;
					break;
				case ParameterType.Object:
					_event.OnTriggerObject -= Filter;
					break;
				case ParameterType.Sprite:
					_event.OnTriggerSprite -= Filter;
					break;
				case ParameterType.String:
					_event.OnTriggerString -= Filter;
					break;
				case ParameterType.Vector3:
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
			if (_event.Type != ParameterType.None)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger();
		}

		private void Filter(bool value)
		{
			if (_event.Type != ParameterType.Boolean)
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
			if (_event.Type != ParameterType.Color)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(float value)
		{
			if (_event.Type != ParameterType.Float)
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
			if (_event.Type != ParameterType.GameObject)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(int value)
		{
			if (_event.Type != ParameterType.Integer)
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
			if (_event.Type != ParameterType.Material)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(Object value)
		{
			if (_event.Type != ParameterType.Object)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(Sprite value)
		{
			if (_event.Type != ParameterType.Sprite)
			{
				Debug.LogAssertion("Trigger type do not match event parameter type", this);
				return;
			}

			Trigger(value);
		}

		private void Filter(string value)
		{
			if (_event.Type != ParameterType.String)
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
			if (_event.Type != ParameterType.Vector3)
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