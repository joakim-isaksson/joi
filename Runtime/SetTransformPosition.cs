using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Joi.UIVariables
{
	public class SetTransformPosition : MonoBehaviour
	{
		[SerializeField] protected Transform _transform;
		[SerializeField] private UIVariableVector3 _uiVariable;
		[SerializeField] protected Space _space;

		private void Reset()
		{
			_transform = gameObject.transform;
			_uiVariable = null;
			_space = Space.Self;
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

		private void HandleOnValueChanged(Vector3 value)
		{
			if (_transform == null)
			{
				Debug.LogWarning("Missing reference to Transform", this);
				return;
			}

			if (_space == Space.Self)
			{
				_transform.localPosition = value;
			}
			else
			{
				_transform.position = value;
			}
		}
	}
}