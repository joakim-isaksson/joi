using UnityEngine;
using UnityEngine.Events;

namespace Joi.UIVariables
{
	public abstract class OnValueChanged<TVariable, TUnityEvent, TValue> : MonoBehaviour
		where TVariable : UIVariable<TValue> where TUnityEvent : UnityEvent<TValue>
	{
		[SerializeField] private TVariable _variable;
		[SerializeField] private TUnityEvent _onValueChanged;

		private void Reset()
		{
			_variable = default;
			_onValueChanged = default;
		}

		private void OnEnable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			OnValueChangedEvent(_variable.Value);

			_variable.OnValueChanged += OnValueChangedEvent;
		}

		private void OnDisable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			_variable.OnValueChanged -= OnValueChangedEvent;
		}

		private void OnValueChangedEvent(TValue value)
		{
			_onValueChanged?.Invoke(value);
		}
	}
}