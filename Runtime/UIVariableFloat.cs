using System;
using UnityEngine;

namespace Joi.UIVariables
{
	[CreateAssetMenu(menuName = "Joi/UI Variables/Float")]
	public class UIVariableFloat : ScriptableObject, UIVariable<float>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private float _initialValue;

		private float _runtimeValue;

		public Action<float> OnValueChanged { get; set; }

		public float Value
		{
			get => _runtimeValue;
			set
			{
				if (Mathf.Approximately(_runtimeValue, value))
				{
					return;
				}

				_runtimeValue = value;
				OnValueChanged?.Invoke(_runtimeValue);
			}
		}

		private void Reset()
		{
			_initialValue = 0f;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			_runtimeValue = _initialValue;
		}

		public override string ToString()
		{
			return _runtimeValue.ToString("F");
		}

		public static implicit operator float(UIVariableFloat uiVariable)
		{
			return uiVariable._runtimeValue;
		}

		public void Add(float value)
		{
			Value += value;
		}

		public void Subtract(float value)
		{
			Value -= value;
		}

		public void Divide(float divisor)
		{
			Value /= divisor;
		}

		public void Multiply(float multiplier)
		{
			Value *= multiplier;
		}
	}
}