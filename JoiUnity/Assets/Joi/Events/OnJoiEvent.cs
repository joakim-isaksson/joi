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

			// TODO: is this optimization for registering worth it?
			var converterReturnType = JoiParameterType.None;

			switch (_event.ParameterType)
			{
				case JoiParameterType.None:
					_event.OnTrigger += Trigger;
					break;
				case JoiParameterType.Boolean:
					_event.OnTriggerBoolean += FilterBoolean;
					converterReturnType = _converter.GetBooleanReturnType();
					break;
				case JoiParameterType.Color:
					_event.OnTriggerColor += Trigger;
					break;
				case JoiParameterType.Float:
					_event.OnTriggerFloat += FilterFloat;
					converterReturnType = _converter.GetFloatReturnType();
					break;
				case JoiParameterType.GameObject:
					_event.OnTriggerGameObject += Trigger;
					break;
				case JoiParameterType.Integer:
					_event.OnTriggerInteger += FilterInteger;
					converterReturnType = _converter.GetIntegerReturnType();
					break;
				case JoiParameterType.Material:
					_event.OnTriggerMaterial += Trigger;
					break;
				case JoiParameterType.Object:
					_event.OnTriggerObject += Trigger;
					break;
				case JoiParameterType.Sprite:
					_event.OnTriggerSprite += Trigger;
					break;
				case JoiParameterType.String:
					_event.OnTriggerString += FilterString;
					converterReturnType = _converter.GetStringReturnType();
					break;
				case JoiParameterType.Vector3:
					_event.OnTriggerVector3 += Trigger;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			switch (converterReturnType)
			{
				case JoiParameterType.Boolean:
					_converter.OnBoolean += Trigger;
					break;
				case JoiParameterType.Float:
					_converter.OnFloat += Trigger;
					break;
				case JoiParameterType.Integer:
					_converter.OnInteger += Trigger;
					break;
				case JoiParameterType.String:
					_converter.OnString += Trigger;
					break;
			}
		}

		private void OnDisable()
		{
			if (_event == null)
			{
				Debug.LogAssertion("Missing event reference", this);
				return;
			}

			var converterReturnType = JoiParameterType.None;

			switch (_event.ParameterType)
			{
				case JoiParameterType.None:
					_event.OnTrigger -= Trigger;
					break;
				case JoiParameterType.Boolean:
					_event.OnTriggerBoolean -= FilterBoolean;
					converterReturnType = _converter.GetBooleanReturnType();
					break;
				case JoiParameterType.Color:
					_event.OnTriggerColor -= Trigger;
					break;
				case JoiParameterType.Float:
					_event.OnTriggerFloat -= FilterFloat;
					converterReturnType = _converter.GetFloatReturnType();
					break;
				case JoiParameterType.GameObject:
					_event.OnTriggerGameObject -= Trigger;
					break;
				case JoiParameterType.Integer:
					_event.OnTriggerInteger -= FilterInteger;
					converterReturnType = _converter.GetIntegerReturnType();
					break;
				case JoiParameterType.Material:
					_event.OnTriggerMaterial -= Trigger;
					break;
				case JoiParameterType.Object:
					_event.OnTriggerObject -= Trigger;
					break;
				case JoiParameterType.Sprite:
					_event.OnTriggerSprite -= Trigger;
					break;
				case JoiParameterType.String:
					_event.OnTriggerString -= FilterString;
					converterReturnType = _converter.GetStringReturnType();
					break;
				case JoiParameterType.Vector3:
					_event.OnTriggerVector3 -= Trigger;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			switch (converterReturnType)
			{
				case JoiParameterType.Boolean:
					_converter.OnBoolean -= Trigger;
					break;
				case JoiParameterType.Float:
					_converter.OnFloat -= Trigger;
					break;
				case JoiParameterType.Integer:
					_converter.OnInteger -= Trigger;
					break;
				case JoiParameterType.String:
					_converter.OnString -= Trigger;
					break;
			}
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

		private void FilterBoolean(bool value)
		{
			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void FilterFloat(float value)
		{
			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void FilterInteger(int value)
		{
			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}

		private void FilterString(string value)
		{
			if (_filter.IsFiltered(value))
			{
				_converter.Convert(value);
			}
		}
	}
}