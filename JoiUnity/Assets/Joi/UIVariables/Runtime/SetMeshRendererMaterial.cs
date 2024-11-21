using UnityEngine;

namespace Joi.UIVariables
{
	public class SetMeshRendererMaterial : MonoBehaviour
	{
		[SerializeField] private MeshRenderer _renderer;
		[SerializeField] private UIVariableMaterial _uiVariable;

		private void Reset()
		{
			_renderer = GetComponentInChildren<MeshRenderer>();
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

		private void HandleOnValueChanged(Material value)
		{
			if (_renderer == null)
			{
				Debug.LogWarning("Missing reference to MeshRenderer", this);
				return;
			}

			_renderer.material = value;
		}
	}
}