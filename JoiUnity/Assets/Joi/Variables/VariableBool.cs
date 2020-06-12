using System;
using UnityEngine;

namespace Joi.Variables
{
	[CreateAssetMenu(menuName = "Joi/Variables/Bool")]
	public class VariableBool : ScriptableObject, IVariable<bool>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private bool _initialValue;

		private bool _runtimeValue;

		public Action<bool> OnValueChanged { get; set; }

		public bool Value
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
			_initialValue = false;
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

		public static implicit operator bool(VariableBool variable)
		{
			return variable._runtimeValue;
		}
		
		public void Toggle()
		{
			Value = !Value;
		}

		public void Not(bool value)
		{
			Value = !value;
		}

		public void And(bool value)
		{
			Value = Value && value;
		}

		public void Or(bool value)
		{
			Value = Value || value;
		}

		public void Xor(bool value)
		{
			Value = Value != value;
		}
	}
}