using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetImageSprite : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private UIVariableSprite _uiVariable;

		private void Reset()
		{
			_image = GetComponentInChildren<Image>();
			_uiVariable = null;
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