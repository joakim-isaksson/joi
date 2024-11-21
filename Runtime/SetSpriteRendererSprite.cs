using UnityEngine;

namespace Joi.UIVariables
{
	public class SetSpriteRendererSprite : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		[SerializeField] private UIVariableSprite _uiVariable;

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

		private void HandleOnValueChanged(Sprite value)
		{
			if (_renderer == null)
			{
				Debug.LogWarning("Missing reference to SpriteRenderer", this);
				return;
			}

			_renderer.sprite = value;
		}
	}
}