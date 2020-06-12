using System;
using UnityEngine;

namespace Joi.Variables
{
	[CreateAssetMenu(menuName = "Joi/Variables/Material")]
	public class VariableMaterial : ScriptableObject, IVariable<Material>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private Material _initialValue;

		private Material _runtimeValue;

		public Action<Material> OnValueChanged { get; set; }

		public Material Value
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
			return _runtimeValue.ToString();
		}

		public static implicit operator Material(VariableMaterial variable)
		{
			return variable._runtimeValue;
		}
	}
}