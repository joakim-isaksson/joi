using UnityEngine;

namespace Joi.Variables
{
	public class SetGameObject : MonoBehaviour
	{
		[SerializeField] private Transform _container;
		[SerializeField] private VariableGameObject _variable;

		[SerializeField] [Tooltip("0 = no limit")]
		private int _maxChildren;

		private void Reset()
		{
			_container = gameObject.transform;
			_variable = null;
			_maxChildren = 1;
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

		private void HandleOnValueChanged(GameObject value)
		{
			if (_container == null)
			{
				Debug.LogWarning("Missing reference to Container", this);
				return;
			}

			if (_maxChildren > 0)
			{
				var removeCount = Mathf.Max(0, _container.childCount - _maxChildren + 1);
				for (var i = removeCount - 1; i >= 0; --i)
				{
					Destroy(_container.GetChild(i).gameObject);
				}
			}

			if (value != null)
			{
				Instantiate(value, _container);
			}
		}
	}
}