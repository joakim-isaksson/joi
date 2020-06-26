using System;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Joi.Events
{
	public class OnJoiEvent : MonoBehaviour
	{
		[SerializeField] private JoiEvent _event;

		[SerializeField] private Converter.BooleanType _convertBoolean;
		[SerializeField] private Converter.FloatType _convertFloat;
		[SerializeField] private Converter.IntegerType _convertInteger;
		[SerializeField] private Converter.StringType _convertString;

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

			_convertBoolean = Converter.BooleanType.None;
			_convertFloat = Converter.FloatType.None;
			_convertInteger = Converter.IntegerType.None;
			_convertString = Converter.StringType.None;

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
			switch (_convertBoolean)
			{
				case Converter.BooleanType.None:
					_onEventBoolean?.Invoke(value);
					break;
				case Converter.BooleanType.Invert:
					_onEventBoolean?.Invoke(Converter.Invert(value));
					break;
				case Converter.BooleanType.Float:
					_onEventFloat?.Invoke(Converter.ToFloat(value));
					break;
				case Converter.BooleanType.Integer:
					_onEventInteger?.Invoke(Converter.ToInteger(value));
					break;
				case Converter.BooleanType.String:
					_onEventString?.Invoke(Converter.ToString(value));
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
			switch (_convertFloat)
			{
				case Converter.FloatType.None:
					_onEventFloat?.Invoke(value);
					break;
				case Converter.FloatType.Negate:
					_onEventFloat?.Invoke(Converter.Negate(value));
					break;
				case Converter.FloatType.Boolean:
					_onEventBoolean?.Invoke(Converter.ToBoolean(value));
					break;
				case Converter.FloatType.FloorToInteger:
					_onEventInteger?.Invoke(Converter.FloorToInteger(value));
					break;
				case Converter.FloatType.CeilToInteger:
					_onEventInteger?.Invoke(Converter.CeilToInteger(value));
					break;
				case Converter.FloatType.RoundToInteger:
					_onEventInteger?.Invoke(Converter.RoundToInteger(value));
					break;
				case Converter.FloatType.String:
					_onEventString?.Invoke(Converter.ToString(value));
					break;
				case Converter.FloatType.StringF:
					_onEventString?.Invoke(Converter.ToStringF(value));
					break;
				case Converter.FloatType.StringF1:
					_onEventString?.Invoke(Converter.ToStringF1(value));
					break;
				case Converter.FloatType.StringN:
					_onEventString?.Invoke(Converter.ToStringN(value));
					break;
				case Converter.FloatType.StringN1:
					_onEventString?.Invoke(Converter.ToStringN1(value));
					break;
				case Converter.FloatType.StringP:
					_onEventString?.Invoke(Converter.ToStringP(value));
					break;
				case Converter.FloatType.StringP1:
					_onEventString?.Invoke(Converter.ToStringP1(value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void TriggerGameObject(GameObject value)
		{
			_onEventGameObject?.Invoke(value);
		}

		private void TriggerInteger(int value)
		{
			switch (_convertInteger)
			{
				case Converter.IntegerType.None:
					_onEventInteger?.Invoke(value);
					break;
				case Converter.IntegerType.Negate:
					_onEventInteger?.Invoke(Converter.Negate(value));
					break;
				case Converter.IntegerType.Boolean:
					_onEventBoolean?.Invoke(Converter.ToBoolean(value));
					break;
				case Converter.IntegerType.Float:
					_onEventFloat?.Invoke(Converter.ToFloat(value));
					break;
				case Converter.IntegerType.String:
					_onEventString?.Invoke(Converter.ToString(value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
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
			switch (_convertString)
			{
				case Converter.StringType.None:
					_onEventString?.Invoke(value);
					break;
				case Converter.StringType.Boolean:
					_onEventBoolean?.Invoke(Converter.ToBoolean(value));
					break;
				case Converter.StringType.Float:
					_onEventFloat?.Invoke(Converter.ToFloat(value));
					break;
				case Converter.StringType.Integer:
					_onEventInteger?.Invoke(Converter.ToInteger(value));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_onEventString?.Invoke(value);
		}

		private void TriggerVector3(Vector3 value)
		{
			_onEventVector3?.Invoke(value);
		}
	}
}