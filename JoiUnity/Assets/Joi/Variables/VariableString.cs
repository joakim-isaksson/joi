using System;
using UnityEngine;

namespace Joi.Variables
{
	[CreateAssetMenu(menuName = "Joi/Variables/String")]
	public class VariableString : ScriptableObject, IVariable<string>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private string _initialValue;

		private string _runtimeValue;

		public Action<string> OnValueChanged { get; set; }

		public string Value
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
			_initialValue = null;
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
			return _runtimeValue;
		}

		public static implicit operator string(VariableString variable)
		{
			return variable._runtimeValue;
		}
	}
}