using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetTextFloat : MonoBehaviour
	{
		[SerializeField] private Text _text;
		[SerializeField] private UIVariableFloat _uiVariable;
		[SerializeField] private string _format;

		private void Reset()
		{
			_text = GetComponentInChildren<Text>();
			_uiVariable = default;
			_format = "F";
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

		private void HandleOnValueChanged(float value)
		{
			if (_text == null)
			{
				Debug.LogWarning("Missing reference to Text", this);
				return;
			}

			_text.text = value.ToString(_format);
		}
	}
}