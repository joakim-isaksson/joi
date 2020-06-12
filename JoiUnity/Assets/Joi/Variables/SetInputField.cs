using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetInputField : MonoBehaviour
	{
		[SerializeField] private InputField _inputField;
		[SerializeField] private VariableString _variable;

		private void Reset()
		{
			_inputField = GetComponentInChildren<InputField>();
			_variable = null;
		}

		private void OnEnable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			HandleOnValueChanged(_variable.Value);

			_variable.OnValueChanged += HandleOnValueChanged;
		}

		private void OnDisable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			_variable.OnValueChanged -= HandleOnValueChanged;
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