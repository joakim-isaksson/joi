using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetInputField : MonoBehaviour
	{
		[SerializeField] private InputField _inputField;
		[SerializeField] private UIVariableString _uiVariable;

		private void Reset()
		{
			_inputField = GetComponentInChildren<InputField>();
			_uiVariable = null;
		}

		private void OnEnable()
		{
			if (_uiVariable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			HandleOnValueChanged(_uiVariable.Value);

			_uiVariable.OnValueChanged += HandleOnValueChanged;
		}

		private void OnDisable()
		{
			if (_uiVariable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			_uiVariable.OnValueChanged -= HandleOnValueChanged;
		}

		private void HandleOnValueChanged(string value)
		{
			if (_inputField == null)
			{
				Debug.LogWarning("Missing reference to InputField", this);
				return;
			}

			_inputField.text = value;
		}
	}
}