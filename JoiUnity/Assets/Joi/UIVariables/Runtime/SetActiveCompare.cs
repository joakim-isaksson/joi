using System;
using UnityEngine;

namespace Joi.UIVariables
{
	public abstract class SetActiveCompare<TVariable, TValue> : MonoBehaviour
		where TVariable : UIVariable<TValue>
		where TValue : IComparable<TValue>
	{
		private enum Comparator
		{
			Less,
			LessOrEqual,
			Equal,
			GreaterOrEqual,
			Greater
		}

		[SerializeField] private GameObject _target;
		[SerializeField] private TVariable _variable;
		[SerializeField] private Comparator _comparator;
		[SerializeField] private TValue _compareTo;

		private void Reset()
		{
			_target = null;
			_variable = default;
			_comparator = Comparator.Equal;
			_compareTo = default;
		}

		private void OnEnable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			OnValueChangedEvent(_variable.Value);

			_variable.OnValueChanged += OnValueChangedEvent;
		}

		private void OnDisable()
		{
			if (_variable == null)
			{
				Debug.LogWarning("Missing reference to Variable", this);
				return;
			}

			_variable.OnValueChanged -= OnValueChangedEvent;
		}

		private void OnValueChangedEvent(TValue value)
		{
			if (_target == null)
			{
				Debug.LogWarning("Missing reference to Target", this);
				return;
			}

			_target.SetActive(Compare(value, _compareTo, _comparator));
		}

		private static bool Compare(TValue valueA, TValue valueB, Comparator comparator)
		{
			var result = valueA.CompareTo(valueB);

			switch (comparator)
			{
				case Comparator.Less:
					return result < 0;
				case Comparator.LessOrEqual:
					return result <= 0;
				case Comparator.Equal:
					return result == 0;
				case Comparator.GreaterOrEqual:
					return result >= 0;
				case Comparator.Greater:
					return result > 1;
				default:
					throw new ArgumentOutOfRangeException(nameof(comparator), comparator, null);
			}
		}
	}
}