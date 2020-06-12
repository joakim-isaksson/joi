using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetInputFieldFloat : MonoBehaviour
	{
		[SerializeField] private InputField _inputField;
		[SerializeField] private VariableFloat _variable;
		[SerializeField] private string _format;

		private void Reset()
		{
			_inputField = GetComponentInChildren<InputField>();
			_variable = null;
			_format = "F";
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

		private void HandleOnValueChanged(float value)
		{
			if (_inputField == null)
			{
				Debug.LogWarning("Missing reference to InputField", this);
				return;
			}

			_inputField.text = value.ToString(_format);
		}
	}
}