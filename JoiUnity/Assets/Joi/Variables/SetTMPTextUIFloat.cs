using TMPro;
using UnityEngine;

namespace Joi.Variables
{
	public class SetTMPTextUIFloat : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private VariableFloat _variable;
		[SerializeField] private string _format;

		private void Reset()
		{
			_text = GetComponentInChildren<TextMeshProUGUI>();
			_variable = default;
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
			if (_text == null)
			{
				Debug.LogWarning("Missing reference to Text", this);
				return;
			}

			_text.text = _variable.Value.ToString(_format);
		}
	}
}