using System;
using UnityEngine;

namespace Joi.UIVariables
{
	[CreateAssetMenu(menuName = "Joi/UI Variables/Vector3")]
	public class UIVariableVector3 : ScriptableObject, UIVariable<Vector3>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private Vector3 _initialValue;

		private Vector3 _runtimeValue;

		public Action<Vector3> OnValueChanged { get; set; }

		public Vector3 Value
		{
			get => _runtimeValue;
			set
			{
				if (_runtimeValue.Equals(value))
				{
					return;
				}

				_runtimeValue = value;
				OnValueChanged?.Invoke(_runtimeValue);
			}
		}

		private void Reset()
		{
			_initialValue = Vector3.zero;
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

		public static implicit operator Vector3(UIVariableVector3 uiVariable)
		{
			return uiVariable._runtimeValue;
		}

		public void Add(Vector3 value)
		{
			Value += value;
		}

		public void Subtract(Vector3 value)
		{
			Value -= value;
		}
	}
}