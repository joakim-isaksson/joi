using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joi.UIEvents
{
	public class UIEventTrigger : MonoBehaviour
	{
		[SerializeField] private TriggerType _trigger;

		[SerializeField] private bool _parameterBoolean;
		[SerializeField] private Color _parameterColor;
		[SerializeField] private float _parameterFloat;
		[SerializeField] private GameObject _parameterGameObject;
		[SerializeField] private int _parameterInteger;
		[SerializeField] private Material _parameterMaterial;
		[SerializeField] private Object _parameterObject;
		[SerializeField] private Sprite _parameterSprite;
		[SerializeField] private string _parameterString;
		[SerializeField] private Vector3 _parameterVector3;

		[SerializeField] private float _delay;

		[SerializeField] private UIEvent _event;

		private void Awake()
		{
			if (_trigger == TriggerType.OnAwake)
			{
				Trigger();
			}
		}

		private void Reset()
		{
			_trigger = TriggerType.Manual;

			_parameterBoolean = false;
			_parameterColor = Color.white;
			_parameterFloat = 0f;
			_parameterGameObject = null;
			_parameterInteger = 0;
			_parameterMaterial = null;
			_parameterObject = null;
			_parameterSprite = null;
			_parameterString = null;
			_parameterVector3 = Vector3.zero;

			_delay = 0f;
			_event = null;
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
			TriggerWithDelay(_delay);
		}

		public void TriggerWithDelay(float delay)
		{
			if (delay > 0f)
			{
				StartCoroutine(TriggerAfterDelay(delay));
			}
			else
			{
				TriggerEvent();
			}
		}

		private IEnumerator TriggerAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			TriggerEvent();
		}

		private void TriggerEvent()
		{
			if (_event == null)
			{
				Debug.LogAssertion("Missing event reference", this);
				return;
			}

			switch (_event.Type)
			{
				case ParameterType.None:
					_event.Trigger();
					break;
				case ParameterType.Boolean:
					_event.Trigger(_parameterBoolean);
					break;
				case ParameterType.Color:
					_event.Trigger(_parameterColor);
					break;
				case ParameterType.Float:
					_event.Trigger(_parameterFloat);
					break;
				case ParameterType.GameObject:
					_event.Trigger(_parameterGameObject);
					break;
				case ParameterType.Integer:
					_event.Trigger(_parameterInteger);
					break;
				case ParameterType.Material:
					_event.Trigger(_parameterMaterial);
					break;
				case ParameterType.Object:
					_event.Trigger(_parameterObject);
					break;
				case ParameterType.Sprite:
					_event.Trigger(_parameterSprite);
					break;
				case ParameterType.String:
					_event.Trigger(_parameterString);
					break;
				case ParameterType.Vector3:
					_event.Trigger(_parameterVector3);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}