using UnityEngine;

namespace Joi.Variables
{
	public class SetSpriteRendererColor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _renderer;
		[SerializeField] private VariableColor _variable;

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