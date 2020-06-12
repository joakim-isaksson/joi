using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetTextColor : MonoBehaviour
	{
		[SerializeField] private Text _text;
		[SerializeField] private VariableColor _variable;

		private void Reset()
		{
			_text = GetComponentInChildren<Text>();
			_variable = default;
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

		private void HandleOnValueChanged(Color value)
		{
			if (_text == null)
			{
				Debug.LogWarning("Missing reference to Text", this);
				return;
			}

			_text.color = value;
		}
	}
}