using System;
using UnityEngine;

namespace Joi.UIVariables
{
	[CreateAssetMenu(menuName = "Joi/UI Variables/GameObject")]
	public class UIVariableGameObject : ScriptableObject, UIVariable<GameObject>, ISerializationCallbackReceiver
	{
#if UNITY_EDITOR
		[TextArea] [SerializeField] private string _description;
#endif

		[SerializeField] private GameObject _initialValue;

		private GameObject _runtimeValue;

		public Action<GameObject> OnValueChanged { get; set; }

		public GameObject Value
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

		public static implicit operator GameObject(UIVariableGameObject uiVariable)
		{
			return uiVariable._runtimeValue;
		}
	}
}