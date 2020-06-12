using UnityEngine;

namespace Joi.Variables
{
	public class SetSpriteRendererSprite : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		[SerializeField] private VariableSprite _variable;

		private void Reset()
		{
			_renderer = GetComponentInChildren<SpriteRenderer>();
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
			if (_renderer == null)
			{
				Debug.LogWarning("Missing reference to SpriteRenderer", this);
				return;
			}

			_renderer.sprite = value;
		}
	}
}