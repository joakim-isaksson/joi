using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetSlider : MonoBehaviour
	{
		[SerializeField] protected Slider _slider;
		[SerializeField] private VariableFloat _variable;

		private void Reset()
		{
			_slider = GetComponentInChildren<Slider>();
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