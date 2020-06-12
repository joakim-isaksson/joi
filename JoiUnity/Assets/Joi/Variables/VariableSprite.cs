using System;
using UnityEngine;

namespace Joi.Variables
{
	[CreateAssetMenu(menuName = "Joi/Variables/Sprite")]
	public class VariableSprite : ScriptableObject, IVariable<Sprite>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private Sprite _initialValue;

		private Sprite _runtimeValue;

		public Action<Sprite> OnValueChanged { get; set; }

		public Sprite Value
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

		public static implicit operator Sprite(VariableSprite variable)
		{
			return variable._runtimeValue;
		}
	}
}