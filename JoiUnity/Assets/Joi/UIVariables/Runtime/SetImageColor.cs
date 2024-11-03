using UnityEngine;
using UnityEngine.UI;

namespace Joi.UIVariables
{
	public class SetImageColor : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private UIVariableColor _uiVariable;

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