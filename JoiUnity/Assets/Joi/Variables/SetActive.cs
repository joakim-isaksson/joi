using UnityEngine;

namespace Joi.Variables
{
	public class SetActive : MonoBehaviour
	{
		[SerializeField] private GameObject _target;
		[SerializeField] private VariableBool _variable;
		[SerializeField] private bool _invert;

		private void Reset()
		{
			_target = null;
			_variable = null;
			_invert = false;
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

		private void OnValueChangedEvent(bool value)
		{
			if (_target == null)
			{
				Debug.LogWarning("Missing reference to Target", this);
				return;
			}

			_target.SetActive(_invert ? !value : value);
		}
	}
}