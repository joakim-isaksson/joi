using UnityEngine;

namespace Joi.Variables
{
	public class SetMeshRendererMaterial : MonoBehaviour
	{
		[SerializeField] private MeshRenderer _renderer;
		[SerializeField] private VariableMaterial _variable;

		private void Reset()
		{
			_renderer = GetComponentInChildren<MeshRenderer>();
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