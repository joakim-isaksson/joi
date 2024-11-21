using System;
using UnityEngine;

namespace Joi.UIVariables
{
	[CreateAssetMenu(menuName = "Joi/UI Variables/Integer")]
	public class UIVariableInt : ScriptableObject, UIVariable<int>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private int _initialValue;

		private int _runtimeValue;

		public Action<int> OnValueChanged { get; set; }

		public int Value
		{
			get => _runtimeValue;
			set
			{
				if (_runtimeValue == value)
				{
					return;
				}

				_runtimeValue = value;
				OnValueChanged?.Invoke(_runtimeValue);
			}
		}

		private void Reset()
		{
			_initialValue = 0;
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
			return _runtimeValue.ToString();
		}

		public static implicit operator int(UIVariableInt uiVariable)
		{
			return uiVariable._runtimeValue;
		}

		public void Floor(float value)
		{
			Value = Mathf.FloorToInt(value);
		}

		public void Ceil(float value)
		{
			Value = Mathf.CeilToInt(value);
		}

		public void Add(int value)
		{
			Value += value;
		}

		public void Subtract(int value)
		{
			Value -= value;
		}

		public void Multiply(int multiplier)
		{
			Value *= multiplier;
		}
	}
}