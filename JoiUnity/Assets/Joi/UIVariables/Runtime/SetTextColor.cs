using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetTextColor : MonoBehaviour
	{
		[SerializeField] private Text _text;
		[SerializeField] private UIVariableColor _uiVariable;

		private void Reset()
		{
			_text = GetComponentInChildren<Text>();
			_uiVariable = default;
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