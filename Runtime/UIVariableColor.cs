using System;
using UnityEngine;

namespace Joi.UIVariables
{
	[CreateAssetMenu(menuName = "Joi/UI Variables/Color")]
	public class UIVariableColor : ScriptableObject, UIVariable<Color>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private Color _initialValue;

		private Color _runtimeValue;

		public Action<Color> OnValueChanged { get; set; }

		public Color Value
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
			_initialValue = Color.white;
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

		public static implicit operator Color(UIVariableColor uiVariable)
		{
			return uiVariable._runtimeValue;
		}
	}
}