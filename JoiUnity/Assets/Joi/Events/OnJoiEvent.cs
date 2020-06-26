using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	public class OnJoiEvent : MonoBehaviour
	{
		[SerializeField] private JoiEvent _event;
		[SerializeField] private JoiParameterType _converter;

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

			switch (_event.ParameterType)
			{
				case JoiParameterType.None:
					_event.OnTriggerBoolean += TriggerBoolean;
					break;
				case JoiParameterType.Boolean:
					_event.OnTriggerBoolean += TriggerBoolean;
					break;
				case JoiParameterType.Color:
					_event.OnTriggerColor += TriggerColor;
					break;
				case JoiParameterType.Float:
					_event.OnTriggerFloat += TriggerFloat;
					break;
				case JoiParameterType.GameObject:
					_event.OnTriggerGameObject += TriggerGameObject;
					break;
				case JoiParameterType.Integer:
					_event.OnTriggerInteger += TriggerInteger;
					break;
				case JoiParameterType.Material:
					_event.OnTriggerMaterial += TriggerMaterial;
					break;
				case JoiParameterType.Object:
					_event.OnTriggerObject += TriggerObject;
					break;
				case JoiParameterType.Sprite:
					_event.OnTriggerSprite += TriggerSprite;
					break;
				case JoiParameterType.String:
					_event.OnTriggerString += TriggerString;
					break;
				case JoiParameterType.Vector3:
					_event.OnTriggerVector3 += TriggerVector3;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnDisable()
		{
			if (_event == null)
			{
				Debug.LogAssertion("Missing event reference", this);
				return;
			}

			switch (_event.ParameterType)
			{
				case JoiParameterType.None:
					_event.OnTrigger -= Trigger;
					break;
				case JoiParameterType.Boolean:
					_event.OnTriggerBoolean -= TriggerBoolean;
					break;
				case JoiParameterType.Color:
					_event.OnTriggerColor -= TriggerColor;
					break;
				case JoiParameterType.Float:
					_event.OnTriggerFloat -= TriggerFloat;
					break;
				case JoiParameterType.GameObject:
					_event.OnTriggerGameObject -= TriggerGameObject;
					break;
				case JoiParameterType.Integer:
					_event.OnTriggerInteger -= TriggerInteger;
					break;
				case JoiParameterType.Material:
					_event.OnTriggerMaterial -= TriggerMaterial;
					break;
				case JoiParameterType.Object:
					_event.OnTriggerObject -= TriggerObject;
					break;
				case JoiParameterType.Sprite:
					_event.OnTriggerSprite -= TriggerSprite;
					break;
				case JoiParameterType.String:
					_event.OnTriggerString -= TriggerString;
					break;
				case JoiParameterType.Vector3:
					_event.OnTriggerVector3 -= TriggerVector3;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void Trigger()
		{
			_onEvent?.Invoke();
		}

		private void TriggerBoolean(bool value)
		{
			switch (_converter)
			{
				case JoiParameterType.None:
				case JoiParameterType.Boolean:
					_onEventBoolean?.Invoke(value);
					break;
				case JoiParameterType.Color:
					_onEventColor?.Invoke(value ? Color.white : Color.clear);
					break;
				case JoiParameterType.Float:
					_onEventFloat?.Invoke(value ? 1f : 0f);
					break;
				case JoiParameterType.GameObject:
					_onEventGameObject?.Invoke(null);
					break;
				case JoiParameterType.Integer:
					_onEventInteger?.Invoke(value ? 1 : 0);
					break;
				case JoiParameterType.Material:
					_onEventMaterial?.Invoke(null);
					break;
				case JoiParameterType.Object:
					_onEventObject?.Invoke(null);
					break;
				case JoiParameterType.Sprite:
					_onEventSprite?.Invoke(null);
					break;
				case JoiParameterType.String:
					_onEventString?.Invoke(value.ToString());
					break;
				case JoiParameterType.Vector3:
					_onEventVector3?.Invoke(value ? Vector3.one : Vector3.zero);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void TriggerColor(Color value)
		{
			_onEventColor?.Invoke(value);
		}

		private void TriggerFloat(float value)
		{
			_onEventFloat?.Invoke(value);
		}

		private void TriggerGameObject(GameObject value)
		{
			_onEventGameObject?.Invoke(value);
		}

		private void TriggerInteger(int value)
		{
			_onEventInteger?.Invoke(value);
		}

		private void TriggerMaterial(Material value)
		{
			_onEventMaterial?.Invoke(value);
		}

		private void TriggerObject(Object value)
		{
			_onEventObject?.Invoke(value);
		}

		private void TriggerSprite(Sprite value)
		{
			_onEventSprite?.Invoke(value);
		}

		private void TriggerString(string value)
		{
			_onEventString?.Invoke(value);
		}

		private void TriggerVector3(Vector3 value)
		{
			_onEventVector3?.Invoke(value);
		}
	}
}