using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Joi.Variables
{
	public class SetTransformScale : MonoBehaviour
	{
		[SerializeField] protected Transform _transform;
		[SerializeField] private VariableVector3 _variable;

		private void Reset()
		{
			_transform = gameObject.transform;
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

		private void HandleOnValueChanged(Vector3 value)
		{
			if (_transform == null)
			{
				Debug.LogWarning("Missing reference to Transform", this);
				return;
			}

			_transform.localScale = value;
		}
	}
}