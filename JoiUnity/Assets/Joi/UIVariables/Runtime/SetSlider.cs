using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetSlider : MonoBehaviour
	{
		[SerializeField] protected Slider _slider;
		[SerializeField] private UIVariableFloat _uiVariable;

		private void Reset()
		{
			_slider = GetComponentInChildren<Slider>();
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

		private void HandleOnValueChanged(float value)
		{
			if (_slider == null)
			{
				Debug.LogWarning("Missing reference to Slider", this);
				return;
			}

			_slider.value = value;
		}
	}
}