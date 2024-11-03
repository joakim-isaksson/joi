using UnityEngine;

namespace Joi.UIVariables
{
	public class SetSpriteRendererColor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		[SerializeField] private UIVariableColor _uiVariable;

		private void Reset()
		{
			_renderer = GetComponentInChildren<SpriteRenderer>();
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
			if (_renderer == null)
			{
				Debug.LogWarning("Missing reference to SpriteRenderer", this);
				return;
			}

			_renderer.color = value;
		}
	}
}