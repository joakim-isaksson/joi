using UnityEngine;

namespace Joi.UIVariables
{
	public class SetActive : MonoBehaviour
	{
		[SerializeField] private GameObject _target;
		[SerializeField] private UIVariableBool _uiVariable;
		[SerializeField] private bool _invert;

		private void Reset()
		{
			_target = null;
			_uiVariable = null;
			_invert = false;
		}

		private void OnEnable()
		{
			if (_uiVariable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			OnValueChangedEvent(_uiVariable.Value);

			_uiVariable.OnValueChanged += OnValueChangedEvent;
		}

		private void OnDisable()
		{
			if (_uiVariable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			_uiVariable.OnValueChanged -= OnValueChangedEvent;
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