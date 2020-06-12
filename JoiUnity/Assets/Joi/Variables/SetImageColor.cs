using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetImageColor : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private VariableColor _variable;

		private void Reset()
		{
			_image = GetComponentInChildren<Image>();
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

		private void HandleOnValueChanged(Color value)
		{
			if (_image == null)
			{
				Debug.LogWarning("Missing reference to Image", this);
				return;
			}

			_image.color = value;
		}
	}
}