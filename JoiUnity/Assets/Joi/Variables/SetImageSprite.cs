using UnityEngine;
using UnityEngine.UI;

namespace Joi.Variables
{
	public class SetImageSprite : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private VariableSprite _variable;

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

		private void HandleOnValueChanged(Sprite value)
		{
			if (_image == null)
			{
				Debug.LogWarning("Missing reference to Image", this);
				return;
			}

			_image.sprite = value;
		}
	}
}