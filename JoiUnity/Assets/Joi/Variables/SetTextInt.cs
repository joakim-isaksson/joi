using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetTextInt : MonoBehaviour
	{
		[SerializeField] private Text _text;
		[SerializeField] private VariableInt _variable;

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

		private void HandleOnValueChanged(int value)
		{
			if (_text == null)
			{
				Debug.LogWarning("Missing reference to Text", this);
				return;
			}

			_text.text = value.ToString();
		}
	}
}